using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
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
    public sealed partial class SensorsPage : Page
    {
        private LightSensor _lightSensor = null;
        private Accelerometer _accelerometer = null;
        private Common.NavigationHelper _navigationHelper = null;

        public SensorsPage()
        {
            this.InitializeComponent();
            Loaded += SensorsPage_Loaded;
            _navigationHelper = new Common.NavigationHelper(this);
        }

        private void SensorsPage_Loaded(object sender, RoutedEventArgs e)
        {
            _lightSensor = Windows.Devices.Sensors.LightSensor.GetDefault();
            if (_lightSensor == null)
            {
                System.Diagnostics.Debug.WriteLine("Light sensor is not support.");
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _accelerometer = Windows.Devices.Sensors.Accelerometer.GetDefault();
            if (_accelerometer == null)
            {
                System.Diagnostics.Debug.WriteLine("Accelerometer sensor is not support.");
            }
            else
            {
                _accelerometer.ReportInterval = 16; // milliseconds
                _accelerometer.Shaken += Accelerometer_Shaken;
                _accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
            base.OnNavigatedTo(e);
        }

        private void Accelerometer_Shaken(Accelerometer sender, AccelerometerShakenEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Shaken");
        }

        private void Accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("X: " + args.Reading.AccelerationX.ToString());
            System.Diagnostics.Debug.WriteLine("Y: " + args.Reading.AccelerationY.ToString());
            System.Diagnostics.Debug.WriteLine("Z: " + args.Reading.AccelerationZ.ToString());
            System.Diagnostics.Debug.WriteLine("time: " + args.Reading.Timestamp.ToString());
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (_accelerometer != null)
            {
                _accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                _accelerometer.ReportInterval = 0;
            }
            base.OnNavigatedFrom(e);
        }

    }
}
