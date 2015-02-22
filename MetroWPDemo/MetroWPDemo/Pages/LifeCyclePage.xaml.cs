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
    public sealed partial class LifeCyclePage : Page
    {
        private Common.NavigationHelper _navigationHelper = null;

        public LifeCyclePage()
        {
            this.InitializeComponent();
        }

        private void NavigationHelper_LoadState(object sender, Common.LoadStateEventArgs e)
        {

            // load data directly from local settings
            //Windows.Storage.ApplicationDataContainer localSettings
            //    = Windows.Storage.ApplicationData.Current.LocalSettings;
            //if (localSettings.Values.ContainsKey("Val"))
            //{
            //    MyTextBox.Text = (localSettings.Values["Val"] as string).ToString();
            //}

            // load data from helper class
             //if(e.PageState != null)
             //{
             //   if(e.PageState.ContainsKey("VAL"))
             //   {
             //       MyTextBox.Text = (e.PageState["VAL"] as string).ToString();
             //   }
             //}
        }

        private void NavigationHelper_SaveState(object sender, Common.SaveStateEventArgs e)
        {
            // save data
            //e.PageState["VAL"] = MyTextBox.Text; 
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper = new Common.NavigationHelper(this);
            _navigationHelper.SaveState += NavigationHelper_SaveState;
            _navigationHelper.LoadState += NavigationHelper_LoadState;

            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // save data directly
            //Windows.Storage.ApplicationDataContainer localSettings 
            //        = Windows.Storage.ApplicationData.Current.LocalSettings;
            //localSettings.Values["Val"] = MyTextBox.Text;
        }
    }
}
