using MetroWPDemo.Strings;

namespace MetroWPDemo
{
    public class LocalizedStrings
    {
        public LocalizedStrings()
        {
        }

        private static Resources localizedresources = new Resources();

        public Resources LocalizedResources { get { return localizedresources; } }
    }
}
