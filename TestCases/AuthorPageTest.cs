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
    class AuthorPageTest
    {

        [Test]
        public void ResumeDownload_linkForAuthenticated_returnsTrue() {
            Assert.True(ResumeDownloadLinkForAuthenticated(getAuthenticatedPage(BrowserFactory.BrowserType.chrome)));
            Assert.True(ResumeDownloadLinkForAuthenticated(getAuthenticatedPage(BrowserFactory.BrowserType.firefox)));
            Debug.WriteLine("ResumeDownload_linkForAuthenticated_returnsTrue");
        }

        [Test]
        public void SignIn_Redirect_ReturnsTrue() {
            Assert.True(ResumeLogInRedirect(BrowserFactory.BrowserType.chrome));
            Assert.True(ResumeLogInRedirect(BrowserFactory.BrowserType.firefox));
            Debug.WriteLine("SignIn_Redirect_ReturnsTrue");
        }

        public IWebDriver getAuthenticatedPage(BrowserFactory.BrowserType browserType) {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, SignInPage.url);
            SignInPage page = new SignInPage(driver);
            PageFactory.InitElements(driver, page);
            page.username.SendKeys("admin");
            page.password.SendKeys("wiedzmin3");
            page.submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl(AuthorPage.url);
            return driver;

        }

        public bool ResumeDownloadLinkForAuthenticated(IWebDriver driver)
        {
            AuthorPage page = new AuthorPage(driver);
            PageFactory.InitElements(driver, page);
            IWebElement downloadLink = page.resumeDownload.FindElement(By.XPath("//*[@id=\"resumeDownloadLink\"]"));
            downloadLink.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            String newTitle = driver.Title;
            driver.Close();
            driver.Dispose();
            return newTitle != "Land Of Battle - Author";
        }

        public bool ResumeLogInRedirect(BrowserFactory.BrowserType browserType)
        {
            IWebDriver driver = BrowserFactory.StartBrowser(browserType, AuthorPage.url);
            AuthorPage page = new AuthorPage(driver);
            PageFactory.InitElements(driver, page);
            IWebElement redirectLink = page.resumeDownload.FindElement(By.XPath("//*[@id=\"signinToDownload\"]"));
            redirectLink.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            String newTitle = driver.Title;
            driver.Close();
            driver.Dispose();
            return newTitle == "Sign in to LandOfBattle";
        }
    }
}
