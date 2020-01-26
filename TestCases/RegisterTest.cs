using LandOfBattlePage.Factory;
using LandOfBattlePage.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    class RegisterTest
    {
        private int modifier;
        [OneTimeSetUp]
        public void CreateUniqueModifier() {
            modifier = Int32.Parse(DateTime.Now.Hour + "" + DateTime.Now.Minute + "" +DateTime.Now.Second);
            Console.WriteLine(modifier);
            Debug.WriteLine(modifier);
        }

        [Test, Order(1)]
        [Category("UserOperations")]
        public void Register_Possible_ReturnsTrue() {
            Assert.True(RegisterPerBrowser(BrowserFactory.BrowserType.chrome, modifier, true));
            Assert.True(RegisterPerBrowser(BrowserFactory.BrowserType.firefox, modifier+1, true));
            //Assert.True(TestBrowser(BrowserFactory.BrowserType.edge, modifier+2));
            Debug.WriteLine("Register_Possible_ReturnsTrue");
        }

        [Test, Order(2)]
        [Category("UserOperations")]
        public void Register_NotUnique_ReturnsFalse() {
            Assert.False(RegisterPerBrowser(BrowserFactory.BrowserType.chrome, modifier, true));
            Assert.False(RegisterPerBrowser(BrowserFactory.BrowserType.firefox, modifier+1, true));
            //Assert.False(TestBrowser(BrowserFactory.BrowserType.edge, modifier+2));
            Debug.WriteLine("Register_NotUnique_ReturnsFalse");
        }

        [Test, Order(3)]
        [Category("UserOperations")]
        public void Register_CookieNotAccepted_ReturnsFalse() {
            Assert.False(SubmitCookiesNotAccepted(BrowserFactory.BrowserType.chrome));
            Assert.False(SubmitCookiesNotAccepted(BrowserFactory.BrowserType.firefox));
            Debug.WriteLine("Register_CookieNotAccepted_ReturnsFalse");
        }

        [Test, Order(4)]
        [Category("UserOperations")]
        public void Register_PasswordsDifferent_returnsFalse()
        {
            Assert.False(RegisterPerBrowser(BrowserFactory.BrowserType.chrome, modifier, false));
            Assert.False(RegisterPerBrowser(BrowserFactory.BrowserType.firefox, modifier + 1, false)); ;
            //Assert.True(TestBrowser(BrowserFactory.BrowserType.edge, modifier+2));
            Debug.WriteLine("Register_Possible_ReturnsTrue");
        }
        [Test]
        public void AlreadyRegistered_redirects_returnsTrue() {
            Assert.True(AlreadyRegistered(BrowserFactory.BrowserType.chrome));
            Assert.True(AlreadyRegistered(BrowserFactory.BrowserType.firefox));
            Debug.WriteLine("AlreadyRegistered_redirects_returnsTrue");
        }

        public bool SubmitCookiesNotAccepted(BrowserFactory.BrowserType browserType) {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, RegisterPage.url);
            var registerPage = new RegisterPage(driver);
            PageFactory.InitElements(driver, registerPage);
            registerPage.Login.SendKeys("cookieTest");
            registerPage.Email.SendKeys("cookieTest@test.pl");
            registerPage.Password.SendKeys("password1");
            registerPage.PasswordConfirmation.SendKeys("password1");
            registerPage.PasswordConfirmation.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
         //   WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
         //   wait.Until(((IJavaScriptExecutor) driver).ExecuteScript("return document.readyState").Equals("complete"));
            try
            {
                IWebElement message = driver.FindElement(By.XPath("//*[@id=\"successMsg\"]"));
                Debug.WriteLine("Page title = " + message);
                driver.Close();
                driver.Dispose();
                return true;
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Dispose();
                Debug.WriteLine("Register Not Succeeded." + "\n" + e.ToString());
                return false;
            }
        }

        public bool AlreadyRegistered(BrowserFactory.BrowserType browserType) {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, RegisterPage.url);
            RegisterPage page = new RegisterPage(driver);
            PageFactory.InitElements(driver, page);
            page.AlreadyRegistered.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            bool result = driver.Title.Contains("Sign in");
            driver.Close();
            driver.Dispose();
            return result;
                }
        
        public bool RegisterPerBrowser(BrowserFactory.BrowserType browserType, int modifier, bool passwordsIdentical) {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, RegisterPage.url);
            var registerPage = new RegisterPage(driver);
            PageFactory.InitElements(driver, registerPage);
            String password1 = "password1";
            String password2 = password1;
            if (!passwordsIdentical) {
                modifier += 5;
                password2 = password2 + "abc";
            }
            registerPage.Login.SendKeys("abcdef" + modifier);
            registerPage.Email.SendKeys("abcdef" + modifier + "@test.pl");
            registerPage.Password.SendKeys(password1);
            registerPage.PasswordConfirmation.SendKeys(password2);
            registerPage.AcceptCookies.Click();
            registerPage.AcceptCookies.Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            try
            {
                IWebElement message = driver.FindElement(By.XPath("//*[@id=\"successMsg\"]"));
                Debug.WriteLine("Page title = " + message);
                driver.Close();
                driver.Dispose();
                return true;
            }
            catch (Exception e) {
                driver.Close();
                driver.Dispose();
                Debug.WriteLine("Register Not Succeeded.");
                return false;
            }
        }
    }
}
