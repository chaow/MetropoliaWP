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
        private AppBarButton _pinButton = null;

        public IOPage()
        {
            this.InitializeComponent();
            _navigationHelper = new Common.NavigationHelper(this);
        }

        private void CreateAppBarButton()
        {
            if(_pinButton == null)
            {
                _pinButton = new AppBarButton();
                _pinButton.Label = App.AppResourceLoader.GetString("AppBarButtonPin");
                _pinButton.Click += PinButton_Click;
                _pinButton.Icon = new SymbolIcon(Symbol.Pin);
            }

            MyBottomAppBar.PrimaryCommands.Clear();
            MyBottomAppBar.PrimaryCommands.Add(_pinButton);
        }

        private async void PinButton_Click(object sender, RoutedEventArgs e)
        {
            bool createSecondaryTile = true;

            // Find all secondary tiles
            var secondaryTiles = await Windows.UI.StartScreen.SecondaryTile.FindAllAsync();
            foreach (var secondaryTile in secondaryTiles)
            {
                // We'll be good citizens and only remove the secondary tile belonging
                // to this scenario. To remove all secondary tiles, remove this check.
                if (secondaryTile.TileId == "ButtonSecondaryTile")
                {
                    // Delete the secondary tile.
                    // Note: On Windows Phone, the call to RequestDeleteAsync deletes the tile without prompting the user
                    // await secondaryTile.RequestDeleteAsync();

                    createSecondaryTile = false;
                }
            }

            if (createSecondaryTile)
            {
                var tile = new Windows.UI.StartScreen.SecondaryTile("ButtonSecondaryTile",
                                                                "ButtonSecondaryTile update",
                                                                "PinTime:" + DateTime.Now.ToString(),
                                                                new Uri("ms-appx:///Assets/wideLogo.png"),
                                                                Windows.UI.StartScreen.TileSize.Default);
                tile.VisualElements.ShowNameOnSquare150x150Logo = true;
                await tile.RequestCreateAsync();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateAppBarButton();

            if (e.Parameter != null)
            {
                string val = e.Parameter.ToString();
                MyInputTextBox.Text = val;
            }
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
            else if (ButtonTile.Name.Equals(b.Name))
            {
                MetroWPDemo.Utils.TileSetter.CreateTiles("ms-appx:///Images/TileImageSquare.png",
                                                        "ms-appx:///Images/TileImageWide.png", 
                                                        DateTime.Now.ToString());
            }
            else if (ButtonBadge.Name.Equals(b.Name))
            {
                var badgeXML = Windows.UI.Notifications.BadgeUpdateManager.GetTemplateContent(Windows.UI.Notifications.BadgeTemplateType.BadgeNumber);
                var badge = badgeXML.SelectSingleNode("/badge") as Windows.Data.Xml.Dom.XmlElement;
                badge.SetAttribute("value", (DateTime.Now.Millisecond % 100).ToString());
                var badgeNotification = new Windows.UI.Notifications.BadgeNotification(badgeXML);
                Windows.UI.Notifications.BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeNotification);
            }
        }

        private async void About_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog msgbox
                    = new Windows.UI.Popups.MessageDialog("About");
            await msgbox.ShowAsync();
        }

    }
}
