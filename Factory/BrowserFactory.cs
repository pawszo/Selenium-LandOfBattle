using LandOfBattlePage.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandOfBattlePage.Factory
{
    class BrowserFactory
    {
        public enum BrowserType {
            chrome, firefox, IE, edge
        }

        public static IWebDriver StartBrowser(BrowserType browserType, String url) {
            IWebDriver driver;
            switch (browserType) {
                case BrowserType.chrome:
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.firefox:
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.IE:
                    driver = new InternetExplorerDriver();
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.edge:
                    driver = new EdgeDriver();
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new BrowserNotSupportedException();
            }
            return driver;
         
        }
    }
}
