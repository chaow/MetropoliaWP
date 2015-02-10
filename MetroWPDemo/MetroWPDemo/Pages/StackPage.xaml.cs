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
    public sealed partial class StackPage : Page
    {
        private int _stackLevel = 0;

        public StackPage()
        {
            this.InitializeComponent();
            Loaded += StackPage_Loaded;
        }

        void StackPage_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonStack.Click += ButtonStack_Click;
            ButtonCleanStack.Click += ButtonCleanStack_Click;
        }

        void ButtonCleanStack_Click(object sender, RoutedEventArgs e)
        {
            // remove the current page
            //Frame.BackStack.RemoveAt(Frame.BackStack.Count - 1);

            // back to main page
            var bs = Frame.BackStack.Where(b => b.SourcePageType.Name == "MainPage").FirstOrDefault();
            if (bs != null)
            {
                Frame.BackStack.Clear();
                Frame.BackStack.Add(bs);
            }

            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        void ButtonStack_Click(object sender, RoutedEventArgs e)
        {
            _stackLevel++;
            this.Frame.Navigate(typeof(Pages.StackPage), _stackLevel);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
            {
                _stackLevel = (int)e.Parameter;
            }
            StackDemo.Text = "stack level: " + _stackLevel.ToString();
        }
    }
}
