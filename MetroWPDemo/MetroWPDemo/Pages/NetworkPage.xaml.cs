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
    public sealed partial class NetworkPage : Page
    {
        private Common.NavigationHelper _navigationHelper = null;

        public NetworkPage()
        {
            this.InitializeComponent();
            _navigationHelper = new Common.NavigationHelper(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            if (ButtonHttpGetGoogle.Name.Equals(b.Name))
            {
                // fire http get (Google)
                int x = await FireHttpGetGoogle();
            }
            else if (ButtonHttpGet.Name.Equals(b.Name))
            {
                // fire http get
                int y = await FireHttpGet();
            }
            else if (ButtonHttpPost.Name.Equals(b.Name))
            {
                // fire http post
                int z = await FireHttpPost();
            }
        }

        private async System.Threading.Tasks.Task<int> FireHttpGetGoogle()
        {
            using (var client = new Windows.Web.Http.HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(new Uri("http://www.google.com")))
                    {
                        System.Diagnostics.Debug.WriteLine("response " + response.StatusCode + " ---- " + response.ToString());

                        // status code 200
                        //if (response.IsSuccessStatusCode)
                        //{
                        // something
                        //}

                        // status code 200
                        if (response.StatusCode == Windows.Web.Http.HttpStatusCode.Ok)
                        {
                            var respMsg = await response.Content.ReadAsStringAsync();
                            System.Diagnostics.Debug.WriteLine("response content: " + respMsg);
                            // update UI
                            NetworkContent.Text = respMsg;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("http get response error: " + e.Message);
                }
            }
            return 1;
        }


        private async System.Threading.Tasks.Task<int> FireHttpGet()
        {
            using(var client = new Windows.Web.Http.HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
                    // adding extra header
                    client.DefaultRequestHeaders.Add("X-Value", "WP-DEMO");
                    using (var response = await client.GetAsync(new Uri("http://users.metropolia.fi/~chaow/wpdemo.php")))
                    {
                        System.Diagnostics.Debug.WriteLine("response " + response.StatusCode + " ---- " + response.ToString());

                        // status code 200
                        if (response.StatusCode == Windows.Web.Http.HttpStatusCode.Ok)
                        {
                            var respMsg = await response.Content.ReadAsStringAsync();
                            System.Diagnostics.Debug.WriteLine("response content: " + respMsg);
                            Models.ComputerList computerList = Utils.JsonHelper.Deserialize<Models.ComputerList>(respMsg);
                            // update UI
                            NetworkContent.Text = computerList.ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("http get response error: " + e.Message);
                }
            }
            return 1;
        }

        private async System.Threading.Tasks.Task<int> FireHttpPost()
        {
            Windows.Web.Http.HttpResponseMessage response = null;
            try
            {
                Models.Computer c = new Models.Computer();
                c.Brand = "Metro";
                c.Price = 100;

                string jsonString = Utils.JsonHelper.Serialize(c);

                // Create the IHttpContent
                Windows.Web.Http.IHttpContent jsonContent
                    = new Windows.Web.Http.HttpStringContent(jsonString, 
                                Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                var client = new Windows.Web.Http.HttpClient();
                client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
                //example server: http://www.posttestserver.com/
                response = await client.PostAsync(new Uri("https://posttestserver.com/post.php"), jsonContent);

                System.Diagnostics.Debug.WriteLine("response " + response.StatusCode + " ---- " + response.ToString());
                if (response.StatusCode == Windows.Web.Http.HttpStatusCode.Ok)
                {
                    // status code 200
                    var respMsg = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine("response " + respMsg);
                }
                else
                {
                    // the rest
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("error: " + ex.Message);
            }
            finally
            {
                try
                {
                    if (response != null)
                    {
                        response.Dispose();
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("response dispose: " + e.Message);
                }
            }

            return 1;
        }

    }
}
