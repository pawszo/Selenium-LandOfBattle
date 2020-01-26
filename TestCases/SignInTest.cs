using LandOfBattlePage.Factory;
using LandOfBattlePage.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandOfBattlePage.TestCases
{
    [TestFixture]
    class SignInTest
    {
        private String correctUsername = "admin";
        private String correctPassword = "wiedzmin3";

        [Test]
        [Category("UserOperations")]
        public void SignIn_credentialsOK_returnsTrue() {
            Assert.True(SignIn(BrowserFactory.BrowserType.chrome, "admin", "wiedzmin3"));
            Assert.True(SignIn(BrowserFactory.BrowserType.firefox, "admin", "wiedzmin3"));
            Debug.WriteLine("SignIn_credentialsOK_returnsTrue");
        }

        [Test]
        [Category("UserOperations")]
        public void SignIn_credentialsWrong_returnsFalse() {
            Assert.False(SignIn(BrowserFactory.BrowserType.chrome, "admin", "dupa123"));
            Assert.False(SignIn(BrowserFactory.BrowserType.firefox, "admin", "dupa123"));
            Debug.WriteLine("SignIn_credentialsWrong_returnsFalse");
        }
        [Test]
        [Category("UserOperations")]
        public void SignIn_passwordWrongCase_returnsFalse()
        {
            Assert.False(SignIn(BrowserFactory.BrowserType.chrome, "admin", "WIEDZMIN3"));
            Assert.False(SignIn(BrowserFactory.BrowserType.firefox, "admin", "WIEDZMIN3"));
            Debug.WriteLine("SignIn_passwordWrongCase_returnsFalse");
        }
        [Test]
        [Category("UserOperations")]
        public void SignIn_usernameCaseInsensitive_returnsTrue()
        {
            Assert.True(SignIn(BrowserFactory.BrowserType.chrome, "Admin", "wiedzmin3"));
            Assert.True(SignIn(BrowserFactory.BrowserType.firefox, "Admin", "wiedzmin3"));
            Debug.WriteLine("SignIn_usernameCaseInsensitive_returnsTrue");
        }

        [Test]
        [Category("UserOperations")]
        public void PasswordLost_Redirect_returnsTrue() {
            Assert.True(PasswordLost(BrowserFactory.BrowserType.chrome));
            Assert.True(PasswordLost(BrowserFactory.BrowserType.firefox));
            Debug.WriteLine("PasswordLost_Redirect_returnsTrue");
        }

        [Test]
        [Category("UserOperations")]
        public void CreateAccount_Redirect_returnsTrue()
        {
            Assert.True(CreateAccount(BrowserFactory.BrowserType.chrome));
            Assert.True(CreateAccount(BrowserFactory.BrowserType.firefox));
            Debug.WriteLine("CreateAccount_Redirect_returnsTrue");
        }


        private bool PasswordLost(BrowserFactory.BrowserType browserType) 
        {
                IWebDriver driver = BrowserFactory.StartBrowser(browserType, SignInPage.url);
                SignInPage page = new SignInPage(driver);
                PageFactory.InitElements(driver, page);
                page.lostPassword.Click();
                bool result = driver.Title.Equals("Change password");
                driver.Close();
                driver.Dispose();
                return result;
            
        }

        private bool CreateAccount(BrowserFactory.BrowserType browserType)
        {
                IWebDriver driver = BrowserFactory.StartBrowser(browserType, SignInPage.url);
                SignInPage page = new SignInPage(driver);
                PageFactory.InitElements(driver, page);
                page.register.Click();
                bool result = driver.Title.Equals("Register to LandOfBattle");
                driver.Close();
                driver.Dispose();
                return result;
            
        }

        private bool SignIn(BrowserFactory.BrowserType browserType, String login, String password) {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, SignInPage.url);
            SignInPage page = new SignInPage(driver);
            PageFactory.InitElements(driver, page);
            page.username.SendKeys(login);
            page.password.SendKeys(password);
            page.submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            bool result = driver.Title.ToLower().Contains("home");
            driver.Close();
            driver.Dispose();
            return result;
        }

    }
}
