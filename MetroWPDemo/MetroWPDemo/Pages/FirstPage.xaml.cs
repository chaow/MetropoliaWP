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
    public sealed partial class FirstPage : Page
    {
        private Common.NavigationHelper _navigationHelper = null;

        public FirstPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.Loaded += MainPage_Loaded;

            _navigationHelper = new Common.NavigationHelper(this);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page loaded.");

            System.Diagnostics.Debug.WriteLine("Debug info: " + App.AppResourceLoader.GetString("DebugContent"));

            Button2.Click += Button_Click;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (Button1.Name.Equals(b.Name))
            {
                System.Diagnostics.Debug.WriteLine("Button 1");
            }
            else if (Button2.Name.Equals(b.Name))
            {
                System.Diagnostics.Debug.WriteLine("Button 2");
            }


            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            Windows.UI.Popups.MessageDialog msgbox
                = new Windows.UI.Popups.MessageDialog("Message Box is displayed");
            // put the dialog content
            //msgbox.Content = "Message Box is displayed";

            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            //Message Box.
            msgbox.Commands.Add(new Windows.UI.Popups.UICommand("Ok",
                        new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));
            msgbox.Commands.Add(new Windows.UI.Popups.UICommand("Quit",
                        new Windows.UI.Popups.UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            msgbox.DefaultCommandIndex = 0;
            // Set the command to be invoked when escape is pressed
            msgbox.CancelCommandIndex = 1;

            await msgbox.ShowAsync();
            //end.

        }

        private void CommandInvokedHandler(Windows.UI.Popups.IUICommand command)
        {
            var Actions = command.Label;
            switch (Actions)
            {
                //Okay Button.
                case "Ok":
                    System.Diagnostics.Debug.WriteLine("OK");
                    break;
                case "Quit":
                    Application.Current.Exit();
                    break;
                //end.
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Using Nullable Types
            // https://msdn.microsoft.com/en-us/library/2cf62fcy(v=vs.120).aspx
            bool? isChecked = ((RadioButton)sender).IsChecked;
            System.Diagnostics.Debug.WriteLine("RadioButton " + isChecked);
            ((RadioButton)sender).IsChecked = false;
        }
    }
}
