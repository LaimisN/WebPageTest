using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace AutomationSolution
{
    class DriverWork
    {
        private static IWebDriver _driver;

        [TearDown]
        public static void TearDown()
        {
            _driver.Close();
        }


        [TestCase("chrome", "Chrome", TestName = "Test Chrome Browser")]
        [TestCase("firefox", "Firefox", TestName = "Test Firefox Browser")]
        [TestCase("opera", "Opera", TestName = "Test Opera Browser")]
        public static void TestBrowser(string browserype, string expectedResult)
        {

            switch (browserype)
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "opera":
                    OperaDriverService service = OperaDriverService.CreateDefaultService("C:\\TEMP\\operadriver_win64", "operadriver.exe");
                    var operaOptions = new OperaOptions
                    {
                        BinaryLocation = "C:\\Users\\ratke\\AppData\\Local\\Programs\\Opera\\76.0.4017.107\\opera.exe",
                        LeaveBrowserRunning = false
                    };
                    _driver = new OperaDriver(service, operaOptions);
                    break;
            }

            SetUpWebPage();

            IWebElement resultBlock = _driver.FindElement(By.CssSelector("#primary-detection > div"));
            Assert.IsTrue(resultBlock.Text.Contains(expectedResult));
        }

        private static void SetUpWebPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


    }
}
