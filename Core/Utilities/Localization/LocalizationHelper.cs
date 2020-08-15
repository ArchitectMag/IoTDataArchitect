using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Core.Utilities.Localization
{
    public class LocalizationHelper : ILocalizationHelper
    {
        private ResourceManager rm;

        public LocalizationHelper()
        {
            rm = new ResourceManager("Core.SystemResources.SharedResource", Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
            return rm.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
