using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SeleniumTests.Helpers
{
    /// <summary>
    /// Web drivers
    /// </summary>
    public enum DriverToUse
    {
        Chrome,
        Edge,
        Firefox // not verified!
    }

    /// <summary>
    /// Driver Factory
    /// </summary>
    public class DriverFactory
    {
        /// <summary>
        /// Creates target Web driver
        /// </summary>
        /// <returns>
        /// Web driver
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IWebDriver Create()
        {
            IWebDriver driver;
            DriverToUse driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");

            switch (driverToUse)
            {
                case DriverToUse.Chrome:
                    driver = new ChromeDriver();
                    break;

                case DriverToUse.Edge:
                    driver = new EdgeDriver();
                    break;

                case DriverToUse.Firefox:
                    driver = new FirefoxDriver();
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid driver: {driverToUse}");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
