using MainProject.Helpers;
using OpenQA.Selenium;

namespace MainProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        // Web elements
        private IWebElement Title() => driver.Element(By.XPath("//article[@id=\"title\"]/h1"));
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
        public void OpenLoginPage() => NavigateTo("https://login-page/");
        public void Login(string username, string password) => SetUsername(username).SetPassword(password).Submit();
        public string GetTextTitle() => Title().Text;
    }
}
