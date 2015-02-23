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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MetroWPDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Common.NavigationHelper _navigationHelper = null;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.Loaded += MainPage_Loaded;

            _navigationHelper = new Common.NavigationHelper(this);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page loaded.");
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (Button1.Name.Equals(b.Name))
            {
                // navigate to first page without passing object
                this.Frame.Navigate(typeof(Pages.FirstPage));
            }
            else if (Button2.Name.Equals(b.Name))
            {
                Models.Student s = new Models.Student();
                s.Name = "Dan";
                this.Frame.Navigate(typeof(Pages.SecondPage), s);
            }
            else if (Button3.Name.Equals(b.Name))
            {
                this.Frame.Navigate(typeof(Pages.HubPage));
            }
            else if (ButtonStack.Name.Equals(b.Name))
            {
                this.Frame.Navigate(typeof(Pages.StackPage));
            }
            else if (ButtonNetwork.Name.Equals(b.Name))
            {
                this.Frame.Navigate(typeof(Pages.NetworkPage));
            }
            else if (ButtonAppLifeCycle.Name.Equals(b.Name))
            {
                this.Frame.Navigate(typeof(Pages.LifeCyclePage));
            }
            else if (ButtonIOTiles.Name.Equals(b.Name))
            {
                this.Frame.Navigate(typeof(Pages.IOPage));
            }
        }


    }
}
