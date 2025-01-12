using OpenQA.Selenium;
using SeleniumTests.Helpers;
using SeleniumTests.PageObjects;

namespace SeleniumTests
{
    [TestClass]
    public class LinkedInLoginTest
    {
        private const string LinkedInUrl = "https://www.linkedin.com";

        /// <summary>
        /// Wait time until the results are displayed on the web page. Just in case
        /// </summary>
        private const int WaitTimeoutMsec = 3000;

        /// <summary>
        /// Active web driver, fetched from config
        /// </summary>
        private IWebDriver _driver;

        /// <summary>
        /// LinkedIn login username, fetched from config
        /// </summary>
        private string _username;

        /// <summary>
        /// LinkedIn login password, fetched from config
        /// </summary>
        private string _password;

        /// <summary>
        /// Initializes web driver and reads login credentials
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _driver = new DriverFactory().Create();

            _username = ConfigurationHelper.Get<string>("Username");
            _password = ConfigurationHelper.Get<string>("Password");
        }

        /// <summary>
        /// Quits active driver and closes the browser window
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            _driver.Quit();
        }

        /// <summary>
        /// Logs in LinkedIn, navigates to the profile page, and retrieves the latest company name
        /// </summary>
        [TestMethod]
        public void LoginAndGetLatestOccupation()
        {
            // . Arrange: Login in and navigate to the user's profile
            new LoginPage(_driver).Login(LinkedInUrl, _username, _password);
            Thread.Sleep(WaitTimeoutMsec);

            new MainPage(_driver).OpenUserProfile();
            Thread.Sleep(WaitTimeoutMsec);

            // . Act: Retrieve the last company name
            string companyName = new ProfilePage(_driver).ReadLastCompanyName();

            // . Assert: Confirm that the company name was successfully retrieved
            Assert.IsNotNull(companyName, $"Latest company name is {companyName}");
        }
    }
}
