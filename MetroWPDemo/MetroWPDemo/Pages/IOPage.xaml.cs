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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MetroWPDemo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IOPage : Page
    {
        private Common.NavigationHelper _navigationHelper = null;

        public IOPage()
        {
            this.InitializeComponent();
            _navigationHelper = new Common.NavigationHelper(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (ButtonSave.Name.Equals(b.Name))
            {
                string text = MyInputTextBox.Text;
                if (string.IsNullOrEmpty(text))
                {
                    Windows.UI.Popups.MessageDialog msgbox
                        = new Windows.UI.Popups.MessageDialog("Content is empty");
                    await msgbox.ShowAsync();
                }
                else
                {
                    // save the content to file
                    // Add:  using Windows.Storage;
                    Windows.Storage.StorageFolder localFolder 
                        = Windows.Storage.ApplicationData.Current.LocalFolder;

                    // Optionally overwrite any existing file with CreationCollisionOption
                    Windows.Storage.StorageFile file
                        = await localFolder.CreateFileAsync("myData.txt", 
                                Windows.Storage.CreationCollisionOption.ReplaceExisting);

                    try
                    {
                        if (file != null)
                        {
                            await Windows.Storage.FileIO.WriteTextAsync(file, text);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        // Error saving data
                    }
                }
            }
            else if (ButtonLoad.Name.Equals(b.Name))
            {
                // load the content from file
                string text = string.Empty;
                Windows.Storage.StorageFolder localFolder 
                    = Windows.Storage.ApplicationData.Current.LocalFolder;

                try
                {
                    Windows.Storage.StorageFile file 
                            = await localFolder.GetFileAsync("myData.txt");
                    text = await Windows.Storage.FileIO.ReadTextAsync(file);
                }
                catch (Exception)
                {
                    // No file to load or error loading it
                }

                MyInputTextBox.Text = text;
            }
            else if (ButtonClear.Name.Equals(b.Name))
            {
                MyInputTextBox.Text = string.Empty;
                Windows.Storage.StorageFolder localFolder 
                    = Windows.Storage.ApplicationData.Current.LocalFolder;
                try
                {
                    Windows.Storage.StorageFile file 
                        = await localFolder.GetFileAsync("myData.txt");
                    await file.DeleteAsync();
                }
                catch (Exception)
                {
                    // file error
                }
            }
        }

        private void ButtonOthers_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (FilePicker.Name.Equals(b.Name))
            {
                Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
                savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                // Dropdown of file types the user can save the file as
                savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
                // Default file name if the user does not type one in or select a file to replace
                savePicker.SuggestedFileName = "New Document";
                savePicker.PickSaveFileAndContinue();
            }
            else if(ButtonDateTime.Name.Equals(b.Name))
            {
                System.Diagnostics.Debug.WriteLine("Date: " + MyDatePicker.Date);
                System.Diagnostics.Debug.WriteLine("Time: " + MyTimePicker.Time);
            }
        }


    }
}
