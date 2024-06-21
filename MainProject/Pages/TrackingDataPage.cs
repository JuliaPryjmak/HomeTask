using MainProject.Helpers;
using OpenQA.Selenium;

namespace MainProject.Pages
{
    public class TrackingDataPage : BasePage
    {
        public TrackingDataPage(IWebDriver driver) : base(driver) { }

        // Web elements
        private IWebElement Title() => driver.Element(By.XPath("//div[contains(@class, 'title')]"));
        private IWebElement SearchButton() => driver.Element(By.Id("search-button"));

        // Actions
        public void Search() => SearchButton().Click();
        public string GetTextTitle() => Title().Text;
        public bool IsSearchButtonEnabled() => SearchButton().Enabled;
    }
}
