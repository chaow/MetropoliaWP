using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Media.Capture;            //For MediaCapture
using Windows.Media.MediaProperties;    //For Encoding Image in JPEG format
using Windows.Storage;                  //For storing Capture Image in App storage or in Picture Library
using Windows.UI.Xaml.Media.Imaging;    //For BitmapImage. for showing image on screen we need BitmapImage format.

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MetroWPDemo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CameraPage : Page
    {
        private Windows.Media.Capture.MediaCapture _captureManager = null;
        private Common.NavigationHelper _navigationHelper = null;

        public CameraPage()
        {
            this.InitializeComponent();
            _navigationHelper = new Common.NavigationHelper(this);
        }

        private async void StartCapturePreview_Click(object sender, RoutedEventArgs e)
        {
            // capabilities
            _captureManager = new MediaCapture();        //Define MediaCapture object
            _captureManager.Failed += CaptureManager_Failed;
            await _captureManager.InitializeAsync();     //Initialize MediaCapture and 
            CapturePreview.Source = _captureManager;     //Start preiving on CaptureElement
            await _captureManager.StartPreviewAsync();   //Start camera capturing 
        }

        private void CaptureManager_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            System.Diagnostics.Debug.WriteLine("Capture Manager Failed " + errorEventArgs.Message);
        }

        private async void StopCapturePreview_Click(object sender, RoutedEventArgs e)
        {
            await _captureManager.StopPreviewAsync();    //stop camera capturing
        }

        private async void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            //Create JPEG image Encoding format for storing image in JPEG type
            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync((DateTime.Now.Ticks + ".jpg"), CreationCollisionOption.ReplaceExisting);

            // take photo and store it on file location.
            await _captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            //// create storage file in Picture Library
            //StorageFile file = await KnownFolders.PicturesLibrary.CreateFileAsync("Photo.jpg",CreationCollisionOption.GenerateUniqueName);

            // Get photo as a BitmapImage using storage file path.
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));

            // show captured image on Image UIElement.
            ImagePreivew.Source = bmpImage;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (_captureManager != null)
            {
                await _captureManager.StopPreviewAsync();
                _captureManager.Dispose();
            }
            base.OnNavigatedFrom(e);
        }
    }
}
