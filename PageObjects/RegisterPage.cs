using LandOfBattlePage.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace LandOfBattlePage.Pages
{
    class RegisterPage
    {
        public static String url = "https://landofbattle.herokuapp.com/register";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"nickname\"]")]
        public IWebElement Login { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"email\"]")]
        public IWebElement Email { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"password1\"]")]
        public IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"password2\"]")]
        public IWebElement PasswordConfirmation { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"acceptCookies\"]")]
        public IWebElement AcceptCookies { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"submitButton\"]")]
        public IWebElement Submit { get; set; }
        [FindsBy(How = How.LinkText, Using = "Already registered?")]
        public IWebElement AlreadyRegistered { get; set; }



        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
