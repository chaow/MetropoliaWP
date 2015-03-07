using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPDemo
{
    public class LocalizedStrings
    {
        /// <summary>
        /// Note that we do not need to specify the namespace when creating the instance
        /// </summary>
        private static Resources localizedResources = new Resources();

        /// <summary>
        /// Gets of AppResources class instance
        /// </summary>
        public static Resources AppResources
        {
            get { return localizedResources; }
        }
    }
}
