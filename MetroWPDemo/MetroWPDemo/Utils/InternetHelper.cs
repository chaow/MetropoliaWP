using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPDemo.Utils
{
    public class InternetHelper
    {
        public static bool isAvailable()
        {
            bool isConnected = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (!isConnected)
            {
                // No internet connection is avaliable. The full functionality of the app isn't avaliable.
            }
            else
            {
                Windows.Networking.Connectivity.ConnectionProfile InternetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
                Windows.Networking.Connectivity.NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
                if (connection == Windows.Networking.Connectivity.NetworkConnectivityLevel.None || connection == Windows.Networking.Connectivity.NetworkConnectivityLevel.LocalAccess)
                {
                    isConnected = false;
                }
            }
            return isConnected;
        }
    }
}
