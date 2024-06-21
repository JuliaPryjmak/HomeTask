using System.Reflection;
using System.Xml;

namespace ApiProject.Initialization
{
    public static class Configuration
    {
        private static XmlDocument _xmlDocument;
        public static string Url { get; private set; }
        public static string Username { get; private set; }
        public static string Username2 { get; private set; }
        public static string AccountId { get; private set; }

        static Configuration()
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Task3.dll.config"));

            Url = GetValue("Url");
            Username = GetValue("Username");
            Username2 = GetValue("Username2");
            AccountId = GetValue("AccountId");
        }

        private static string GetValue(string value)
        {
            return _xmlDocument.SelectSingleNode("//setting[@name='" + value + "']/value").InnerText;
        }

    }
}
