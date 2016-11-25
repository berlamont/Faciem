using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Faciem
{
	public partial class Faciem
	{
		readonly VisionServiceClient visionClient;
		public Faciem()
		{
			InitializeComponent();
			visionClient = new VisionServiceClient("9b90f7f4a3de4d928d8ed2105806d263");
		}
		async Task<AnalysisResult> AnalyzePictureAsync(Stream inputFile)
		{

			if (!CrossConnectivity.Current.IsConnected)
			{
				await DisplayAlert("Network error",
					"Please check your network connection and retry.", "OK");
				return null;
			}

			var visualFeatures = new VisualFeature[] { VisualFeature.Adult,
				VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description,
				VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };

			AnalysisResult analysisResult =
				await visionClient.AnalyzeImageAsync(inputFile,
				visualFeatures);

			return analysisResult;
		}

		async void TakePictureButton_Clicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", "No camera available.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				SaveToAlbum = true,
				Name = "test.jpg"
			});

			if (file == null)
				return;

			Progress.IsVisible = true;
			Progress.IsRunning = true;

			Image1.Source = ImageSource.FromStream(() => file.GetStream());
			BindingContext = await AnalyzePictureAsync(file.GetStream());

			Progress.IsRunning = false;
			Progress.IsVisible = false;
		}

		async void UploadPictureButton_Clicked(object sender, EventArgs e)
		{
			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("No upload", "Picking a photo is not supported.", "OK");
				return;
			}

			var file = await CrossMedia.Current.PickPhotoAsync();
			if (file == null)
				return;

			Progress.IsVisible = true;
			Progress.IsRunning = true;
			Image1.Source = ImageSource.FromStream(() => file.GetStream());

			try
			{
				BindingContext = await AnalyzePictureAsync(file.GetStream());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "OK");
				return;
			}
			finally
			{
				Progress.IsRunning = false;
				Progress.IsVisible = false;
			}
		}
	}
}
