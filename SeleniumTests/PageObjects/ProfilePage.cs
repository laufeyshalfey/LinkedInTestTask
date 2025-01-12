using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTests.PageObjects
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Latest company name element
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@data-field='experience_company_logo']//span[@aria-hidden='true']")]
        public IWebElement LatestCompanyName { get; set; }

        /// <summary>
        /// Reads the last company name from the profile page
        /// </summary>
        /// <returns>
        /// Company name as a string
        /// </returns>
        public string ReadLastCompanyName()
        {
            try
            {
                IWebElement companyName = WaitForElementIsVisible(By.XPath("//a[@data-field='experience_company_logo']//span[@aria-hidden='true']"));

                return companyName.Text.Trim();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Couldn't find latest company! Can the user be a freshman?");
            }
            return null;
        }
    }
}
