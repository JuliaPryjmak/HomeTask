using MainProject.Helpers;
using OpenQA.Selenium;

namespace MainProject.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        // Web elements
        private IWebElement Title() => driver.Element(By.Id("title"));
        private IWebElement SearchButton() => driver.Element(By.XPath("//button[text()=\"Submit\"]"));
        private IWebElement LoginButton() => driver.Element(By.Id("loginButton"));
        private IWebElement InformationButton() => driver.Element(By.Id("informationButton"));
        private IWebElement ContactButton() => driver.Element(By.Id("contactButton"));
        private IWebElement HelpButton() => driver.Element(By.Id("helpButton"));

        // Actions
        public void OpenHomePage() => NavigateTo("https://homepage/");
        public void Search() => SearchButton().Click();
        public void OpenInformationPage() => InformationButton().Click();
        public bool IsPageTitleDisplayed() => Title().Displayed;
    }
}
