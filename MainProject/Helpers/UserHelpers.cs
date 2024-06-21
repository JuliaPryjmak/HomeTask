using NUnit.Framework;

namespace MainProject.Helpers
{
    public class UserHelpers
    {
        private readonly List<string> _registeredUsers;

        public UserHelpers()
        {
            // There is an example of list. In the future this might change to change using database
            _registeredUsers = new List<string> { "usernameTest", "usernameTest2" };
        }

        public bool IsUserRegistered(string username)
        {
            return _registeredUsers.Contains(username);
        }

        public void CheckUserIsRegistered(string username)
        {
            bool isRegistered = IsUserRegistered(username);
            Assert.IsTrue(isRegistered, $"The user with such {username} is not registered.");
        }
    }
}
