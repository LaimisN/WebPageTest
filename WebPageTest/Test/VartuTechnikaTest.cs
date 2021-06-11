using AutomationSolution.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Test
{
    public class VartuTechnikaTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "http://vartutechnika.lt/";
            IWebElement cookies = _driver.FindElement(By.Id("cookiescript_close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(x => cookies.Displayed);
            cookies.Click();

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("2000", "2000", true, true, "780.49€", TestName = "2000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 x 2000 = 692.35€")]
        [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 x 2000 + Vartų montavimo darbai = 989.21€")]
        public static void TestVartuAutomatika(string width, string height, bool gateAuto, bool darbai, string result)
        {
            VartuTechnikaPage page = new VartuTechnikaPage(_driver);
            page.InsertWidthAndHeight(width, height)
                .CheckAutoCheckBox(gateAuto)
                .CheckWorksCheckBox(darbai)
                .ClickCalculateButton()
                .CheckResult(result);
        }
    }
}
