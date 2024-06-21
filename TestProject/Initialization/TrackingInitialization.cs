using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject.Initialization
{
    [TestFixture]
    public class TrackingInitialization
    {
        [SetUp]
        public virtual void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Close();
        }


        public IWebDriver Driver { get; set; }
    }
}
