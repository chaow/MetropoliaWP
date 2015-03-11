using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class ExtendedSplashPage : Page
    {

        // Reference:
        // https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868191.aspx


        private SplashScreen _splash; // Variable to hold the splash screen object.
        internal Frame _rootFrame;

        public ExtendedSplashPage(SplashScreen splashscreen, bool loadState)
        {
            InitializeComponent();

            _splash = splashscreen;

            // Create a Frame to act as the navigation context
            _rootFrame = new Frame();
            
            Loaded += ExtendedSplashPage_Loaded;

            // Restore the saved session state if necessary
            RestoreStateAsync(loadState);
        }

        private async void RestoreStateAsync(bool loadState)
        {
            if (loadState)
            {
                await Common.SuspensionManager.RestoreAsync();
                System.Diagnostics.Debug.WriteLine("restore data");
            }
        }

        private async void ExtendedSplashPage_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.UI.ViewManagement.StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            // Hide the status bar
            await statusBar.HideAsync();

            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(3));

            // Navigate to mainpage
            _rootFrame.Navigate(typeof(Pages.MainPage));
            // Place the frame in the current Window
            Window.Current.Content = _rootFrame;            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
