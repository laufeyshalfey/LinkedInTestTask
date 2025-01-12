using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTests.PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Profile URL element
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='ember-view link-without-hover-visited display-flex flex-column mb2']")]
        public IWebElement ProfileUrl { get; set; }

        /// <summary>
        /// Navigates to User Profile page
        /// </summary>
        public void OpenUserProfile()
        {
            IWebElement profileLink = WaitForElementToBeClickable(By.XPath("//a[@class='ember-view link-without-hover-visited display-flex flex-column mb2']"));
            profileLink.Click();
        }
    }
}
