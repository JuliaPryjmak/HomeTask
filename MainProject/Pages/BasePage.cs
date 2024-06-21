using OpenQA.Selenium;

namespace MainProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Actions
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
