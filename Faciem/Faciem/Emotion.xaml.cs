using System;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;


namespace Faciem
{
	public partial class Emotion : ContentPage
	{
		public Emotion()
		{
			InitializeComponent();
		}
		async void TakePictureButton_Clicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("Camera Not Available", "No camera available.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { PhotoSize = PhotoSize.Small, SaveToAlbum = true, CompressionQuality = 85, Name = "test.jpg" });

			if (file == null)
				return;

			Progress.IsVisible = true;
			Progress.IsRunning = true;
			Image1.Source = ImageSource.FromStream(() => file.GetStream());

			try
			{
				BindingContext = await EmotionService.GetAverageHappinessScoreAsync(file.GetStream());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message + ": " + ex.InnerException, "OK");
			}
			finally
			{
				Progress.IsRunning = false;
				Progress.IsVisible = false;
			}
		}

		async void UploadPictureButton_Clicked(object sender, EventArgs e)
		{
			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("No upload", "Picking a photo is not supported.", "OK");
				return;
			}

			var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions() { CompressionQuality = 85, PhotoSize = PhotoSize.Small });
			if (file == null)
				return;

			Progress.IsVisible = true;
			Progress.IsRunning = true;
			Image1.Source = ImageSource.FromStream(() => file.GetStream());

			try
			{
				BindingContext = await EmotionService.GetAverageHappinessScoreAsync(file.GetStream());
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message + ": " + ex.InnerException, "OK");
			}
			finally
			{
				Progress.IsRunning = false;
				Progress.IsVisible = false;
			}
		}
	}
}
