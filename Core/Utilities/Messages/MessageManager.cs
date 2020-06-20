using Core.Utilities.Messages;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Core.Utilities.Localization
{
    public class MessageManager : IMessage
    {
        private ResourceManager rm;

        public MessageManager()
        {
            rm = new ResourceManager("Core.SystemResources.SystemMessages", Assembly.GetExecutingAssembly());
        }

        public string GetMessage(string name)
        {
            return rm.GetString(name,CultureInfo.CurrentCulture);
        }
    }
}
