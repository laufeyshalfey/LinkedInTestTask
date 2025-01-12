using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumTests.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Username field
        /// </summary>
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement UsernameFiled { get; set; }

        /// <summary>
        /// Password field
        /// </summary>
        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordFiled { get; set; }

        /// <summary>
        /// First 'Sign In' button
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "a.nav__button-secondary")]
        public IWebElement SignInButton1 { get; set; }

        /// <summary>
        /// Second 'Sign In' button
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement SignInButton2 { get; set; }

        /// <summary>
        /// Goes to URL and logs in via username and password
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string url, string username, string password)
        {
            NavigateToUrl(url);
            SignInButton1.Click();

            UsernameFiled.SendKeys(username);
            PasswordFiled.SendKeys(password);

            SignInButton2.Click();
        }
    }
}
