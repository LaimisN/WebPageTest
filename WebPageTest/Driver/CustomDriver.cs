using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Driver
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetIncognitoChrome()
        {
            return GetDriver(Browsers.IncognitoChrome);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webdriver = null;
            switch (browserName)
            {
                case Browsers.Chrome:
                    webdriver = new ChromeDriver();
                    break;
                case Browsers.IncognitoChrome:
                    webdriver = GetIncognitoChromeOption();
                    break;
                case Browsers.Firefox:
                    webdriver = new FirefoxDriver();
                    break;
                default:
                    webdriver = new ChromeDriver();
                    break;
            }

            webdriver.Manage().Window.Maximize();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webdriver;
        }

        private static IWebDriver GetIncognitoChromeOption()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("incognito");
            //options.AddArgument("start-maximized");

            options.AddArguments("headless", "start-maximized");

            return new ChromeDriver(options);
        }

    }
}
