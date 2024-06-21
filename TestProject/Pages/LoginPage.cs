using OpenQA.Selenium;
using TestProject.Helpers;

namespace TestProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Web elements
        private IWebElement Username() => driver.Element(By.Id("username"));
        private IWebElement Password() => driver.Element(By.Id("password"));
        private IWebElement SubmitButton() => driver.Element(By.Id("submitButton"));


        // Actions
        public LoginPage SetUsername(string value)
        {
            Username().SendKeys(value);

            return this;
        }
        public LoginPage SetPassword(string value)
        {
            Password().SendKeys(value);

            return this;
        }

        public void Submit() => SubmitButton().Click();
        public void Login(string username, string password) => SetUsername(username).SetPassword(password).Submit();
    }
}
