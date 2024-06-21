using MainProject.Context;
using MainProject.Helpers.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MainProject.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly IEnvironmentSettings _environmentSettings;
        private readonly BaseContext _context;


        public LoginStepDefinitions(IWebDriver driver, BaseContext context, IEnvironmentSettings environmentSettings)
        {
            _driver = driver;
            _context = context;
            _environmentSettings = environmentSettings;
        }

        [Given(@"I’m not logged in with a genuine user")]
        public void GivenIMNotLoggedInWithAGenuineUser()
        {
            _context.HomePage.OpenHomePage();
        }

        [Given(@"Valid user credentials are already registered")]
        public void GivenValidUserCredentialsAreAlreadyRegistered()
        {
            _context.UserHelpers.CheckUserIsRegistered(_environmentSettings.Username);
        }

        [Given(@"I’m on the login screen")]
        public void GivenIMOnTheLoginScreen()
        {
            _context.LoginPage.OpenLoginPage();
        }

        [When(@"I navigate to any page on the tracking site")]
        public void WhenINavigateToAnyPageOnTheTrackingSite()
        {
            _context.HomePage.OpenInformationPage(); // an example of one page
        }

        [When(@"I enter a valid username and password and submit")]
        public void WhenIEnterAValidUsernameAndPasswordAndSubmit()
        {
            _context.LoginPage.Login(_environmentSettings.Username, _environmentSettings.Password);
        }

        [Then(@"I am presented with a login screen")]
        public void ThenIAmPresentedWithALoginScreen()
        {
            Assert.AreEqual("Please login into your account", _context.LoginPage.GetTextTitle());
            // additional Assert that can theck that it's Login page
        }

        [Then(@"I am logged in successfully")]
        public void ThenIAmLoggedInSuccessfully()
        {
            string currentUrl = _driver.Url;
            Assert.That(currentUrl, Is.EqualTo(_environmentSettings.LoggedPage));
            Assert.AreEqual("Welcome to tracking data", _context.TrackingDataPage.GetTextTitle());
            Assert.IsTrue(_context.TrackingDataPage.IsSearchButtonEnabled());
        }
    }
}
