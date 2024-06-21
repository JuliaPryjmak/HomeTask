using TestProject.Initialization;
using TestProject.Pages;

namespace TestProject.Tests
{
    [TestFixture]
    public class LoginTests : TrackingInitialization
    {
        private LoginPage LoginPage;

        [SetUp]
        public override void Setup()
        {
            base.Setup();           
            LoginPage = new LoginPage(Driver);
        }

        [Test]
        public void LoginIsSuccessul()
        {
            // Act
            LoginPage.NavigateTo(Configuration.BaseUrl);
            LoginPage.Login(Configuration.Username, Configuration.Password);

            // Assert
            string currentUrl = Driver.Url;
            Assert.That(currentUrl, Is.EqualTo(Configuration.MainPage));
        }
    }
}
