using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using MainProject.Helpers.Configuration;
using MainProject.Pages;
using MainProject.Helpers;
using MainProject.Context;

namespace MainProject.Hook
{
    [Binding]
    public class Hook
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private static IConfiguration config;

        public Hook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_driver);

            if (config == null)
            {
                config = new ConfigurationBuilder()
                    .AddJsonFile("specflow.json", optional: false, reloadOnChange: true)
                    .Build();
            }

            var configuration = new EnvironmentSettings(config);
            _objectContainer.RegisterInstanceAs<IEnvironmentSettings>(configuration);
            _objectContainer.RegisterTypeAs<UserHelpers, UserHelpers>();
            _objectContainer.RegisterTypeAs<HomePage, HomePage>();
            _objectContainer.RegisterTypeAs<LoginPage, LoginPage>();
            _objectContainer.RegisterTypeAs<TrackingDataPage, TrackingDataPage>();

            var userHelpers = _objectContainer.Resolve<UserHelpers>();
            var homePage = _objectContainer.Resolve<HomePage>();
            var loginPage = _objectContainer.Resolve<LoginPage>();
            var trackingDataPage = _objectContainer.Resolve<TrackingDataPage>();
            var context = new BaseContext(userHelpers, homePage, loginPage, trackingDataPage);

            _objectContainer.RegisterInstanceAs<BaseContext>(context);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
