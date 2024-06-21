using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace MainProject.Helpers
{
    public static class ExtensionMethods
    {
        public static IWebElement Element(this IWebDriver driver, By bySelector, TimeSpan waitTimeout = default)
        {
            IWebElement element = null;

            if (waitTimeout == default)
                waitTimeout = TimeSpan.FromMinutes(1);
            driver.WaitUntilPageIsReady();

            try
            {
                element = new WebDriverWait(driver, waitTimeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(bySelector));
                ((IJavaScriptExecutor)driver).ExecuteScript("var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0); var viewPortWidth = Math.max(document.documentElement.clientWidth, window.innerWidth || 0); var elementTop = arguments[0].getBoundingClientRect().top; var elementLeft = arguments[0].getBoundingClientRect().left; window.scrollBy(elementLeft - (viewPortWidth/2), elementTop - (viewPortHeight/2));", element);
            }
            catch (Exception)
            {
                Assert.Fail("The specified element does not exist. SelectorName: " + bySelector.ToString());
            }

            return element;
        }

        public static IWebDriver WaitUntilPageIsReady(this IWebDriver driver, TimeSpan waitTimeout = default)
        {
            if (waitTimeout == default)
                waitTimeout = TimeSpan.FromMinutes(1);

            try
            {
                string waitScript = "return (!window.jQuery || jQuery.active == 0) && document.readyState == 'complete'";
                new WebDriverWait(driver, waitTimeout).Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript(waitScript));
            }
            catch (Exception)
            {
                Assert.Fail("Wait until scripts are complete failed. Make sure the page(s) loaded properly.");
            }

            return driver;
        }
    }
}
