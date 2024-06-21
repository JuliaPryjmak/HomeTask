
namespace MainProject.Helpers.Configuration
{
    public interface IEnvironmentSettings
    {
        string Username { get; }
        string Password { get; }
        string LoggedPage { get; }
    }
}
