using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Faciem
{
	public partial class Emotion : ContentPage
	{
		public Emotion()
		{
			InitializeComponent();
		}

		public async Task AnalyzeImageAsync(string imageUrl)
		{
			string result;
			try
			{
				using (var client = new HttpClient())
				{
					var stream = await client.GetStreamAsync(imageUrl);

					var emotion = await EmotionService.GetAverageHappinessScoreAsync(stream);

					result = EmotionService.GetHappinessMessage(emotion);
				}
			}
			catch (Exception ex)
			{
				result = "Unable to analyze image";
			}

			await DisplayAlert("Problem",result,"Ok");

		}


	}


}
