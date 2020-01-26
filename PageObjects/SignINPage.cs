using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandOfBattlePage.PageObjects
{
    class SignInPage
    {
        public static String url = "https://landofbattle.herokuapp.com/signin";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"nickname\"]")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"password1\"]")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/form/button")]
        public IWebElement submit { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/form/a")]
        public IWebElement lostPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/form/p/a")]
        public IWebElement register { get; set; }

        public SignInPage(IWebDriver driver) {
            this.driver = driver;
        }


    }
}
