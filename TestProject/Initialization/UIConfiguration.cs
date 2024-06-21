using System.Reflection;
using System.Xml;

namespace TestProject.Initialization
{
    internal class Configuration
    {
        private static XmlDocument _xmlDocument;
        public static string BaseUrl { get; private set; }
        public static string Username { get; private set; }
        public static string Password { get; private set; }
        public static string MainPage { get; private set; }

        static Configuration()
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Task2.dll.config"));

            BaseUrl = GetValue("Url");
            Username = GetValue("Username");
            Password = GetValue("Password");
            MainPage = GetValue("MainPage");
        }

        private static string GetValue(string value)
        {
            return _xmlDocument.SelectSingleNode("//setting[@name='" + value + "']/value").InnerText;
        }
    }
}
