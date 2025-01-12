using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTests.PageObjects
{
    public abstract class BasePage
    {
        public const uint TimeoutInSec = 10;

        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        /// <summary>
        /// Constructor that initializes the WebDriver and WebDriverWait
        /// </summary>
        /// <param name="driver">
        /// The target WebDriver
        /// </param>
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeoutInSec));
        }

        /// <summary>
        /// Waits until an element is visible and returns it
        /// </summary>
        /// <param name="locator">
        /// Locator to find the element
        /// </param>
        /// <returns>
        /// WebElement that was located
        /// </returns>
        protected IWebElement WaitForElementIsVisible(By locator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be clickable and returns the IWebElement
        /// </summary>
        /// <param name="locator">
        /// By locator of the element
        /// </param>
        /// <returns>
        /// IWebElement
        /// </returns>
        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Navigates to the URL provided
        /// </summary>
        /// <param name="url">
        /// URL to navigate to
        /// </param>
        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
