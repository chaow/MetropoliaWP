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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MetroWPDemo.UserControls
{
    public sealed partial class UserControlDemo : UserControl
    {
        public UserControlDemo()
        {
            this.InitializeComponent();
            Loaded += UserControlDemo_Loaded;
        }

        void UserControlDemo_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonClickMe.Click += ButtonClickMe_Click;
        }

        void ButtonClickMe_Click(object sender, RoutedEventArgs e)
        {
            Popup thisPopup = this.Parent as Popup;
            thisPopup.IsOpen = false;
        }

    }
}
