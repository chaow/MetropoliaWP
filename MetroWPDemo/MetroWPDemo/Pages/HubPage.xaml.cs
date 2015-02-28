﻿using System;
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
    public sealed partial class HubPage : Page
    {
        private ViewModel.HubPageViewModel _hubPageViewModel = null;

        private Common.NavigationHelper _navigationHelper = null;

        private AppBarButton _appBarAttachButton = null;

        public HubPage()
        {
            this.InitializeComponent();
            Loaded += HubPage_Loaded;
            _navigationHelper = new Common.NavigationHelper(this);
        }

        private void CreateAppBarButton()
        {
            if (_appBarAttachButton == null)
            {
                _appBarAttachButton = new AppBarButton();
                _appBarAttachButton.Label = "Attach";
                _appBarAttachButton.Click += AttachButton_Click; 
                _appBarAttachButton.Icon = new SymbolIcon(Symbol.Attach);
            }

            MyBottomAppBar.PrimaryCommands.Clear();
            MyBottomAppBar.PrimaryCommands.Add(_appBarAttachButton);
        }

        private async void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog msgbox
                = new Windows.UI.Popups.MessageDialog("Attach");
            await msgbox.ShowAsync();
        }

        void HubPage_Loaded(object sender, RoutedEventArgs e)
        {
            _hubPageViewModel = new ViewModel.HubPageViewModel();
            this.DataContext = _hubPageViewModel;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreateAppBarButton();

            System.Diagnostics.Debug.WriteLine("---Page OnNavigatedTo ---");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("---Page OnNavigatedFrom ---");
            base.OnNavigatedFrom(e);
        }


        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("---Page OnNavigatingFrom ---");
            base.OnNavigatingFrom(e);
        }

        private void StackPanel_Holding(object sender, HoldingRoutedEventArgs e)
        {
            // pop up the menu
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void MenuFlyoutItemDelete_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;

            if (item != null)
            {
                // fetch the list item content
                Models.Person person = item.DataContext as Models.Person;
                if (person != null)
                {
                    _hubPageViewModel.RemovePersonFromPersonHub1List(person);
                }
            }
        }

        private async void MenuFlyoutItemHello_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;

            if (item != null)
            {
                // fetch the list item content
                Models.Person person = item.DataContext as Models.Person;
                if(person != null)
                {
                    Windows.UI.Popups.MessageDialog msgbox
                        = new Windows.UI.Popups.MessageDialog("Hello! " + person.Name);
                    await msgbox.ShowAsync();
                }
            }

        }

        private async void HUB_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog msgbox
                = new Windows.UI.Popups.MessageDialog("About HUB");
            await msgbox.ShowAsync();
        }
    }
}
