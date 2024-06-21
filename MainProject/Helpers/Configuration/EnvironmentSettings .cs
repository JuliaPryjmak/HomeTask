using Microsoft.Extensions.Configuration;

namespace MainProject.Helpers.Configuration
{
    public class EnvironmentSettings : IEnvironmentSettings
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string LoggedPage { get; private set; }

        public EnvironmentSettings(IConfiguration configuration)
        {
            Username = configuration["Username"];
            Password = configuration["Password"];
            LoggedPage = configuration["LoggedPage"];
        }
    }
}
