//System
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace MyIoT.Core.Utilities.Localization;

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
