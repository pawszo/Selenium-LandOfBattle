using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandOfBattlePage.PageObjects
{
    class AuthorPage
    {
        public static String url = "https://landofbattle.herokuapp.com/author";
        public IWebDriver driver { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"resumeDownload\"]")]
        public IWebElement resumeDownload;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[2]/img")]
        public IWebElement photo;

        public AuthorPage(IWebDriver driver) {
            this.driver = driver;
        }

    }
}
