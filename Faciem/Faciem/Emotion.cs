﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Faciem.Data;
using Microsoft.ProjectOxford.Emotion;

namespace Faciem
{
	public static class EmotionService
	{
		static async Task<Microsoft.ProjectOxford.Emotion.Contract.Emotion[]> GetHappinessAsync(Stream stream)
		{
			var emotionClient = new EmotionServiceClient(ApiKey.API_KEY);

			var emotionResults = await emotionClient.RecognizeAsync(stream);

			if ((emotionResults != null) && emotionResults.Any()) return emotionResults;
			throw new Exception("Can't detect face");
		}

		//Average happiness calculation in case of multiple people
		public static async Task<float> GetAverageHappinessScoreAsync(Stream stream)
		{
			var emotionResults = await GetHappinessAsync(stream);

			var score = emotionResults.Aggregate<Microsoft.ProjectOxford.Emotion.Contract.Emotion, float>(0, (current, emotionResult) => current + emotionResult.Scores.Happiness);

			return score / emotionResults.Count();
		}

		public static string GetHappinessMessage(float score)
		{
			score = score * 100;
			var result = Math.Round(score, 2);

			if (score >= 50)
				return result + " % :-)";
			return result + "% :-(";
		}
	}
}