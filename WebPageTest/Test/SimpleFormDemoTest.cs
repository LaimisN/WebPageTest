
using AutomationSolution.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace AutomationSolution.Test
{
    public class SimpleFormDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            _driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public static void TestSingleInputField()
        {
            SimpleFormDemoPage page = new SimpleFormDemoPage(_driver);
            string text = "Penktadienis";

            page.InsertTextToSingleInputField(text);
            page.ClickShowMessageButton();
            page.VerifySingleInputField(text);
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        public static void TestSumBlock(string firstInput, string secondInput, string result)
        {
            SimpleFormDemoPage page = new SimpleFormDemoPage(_driver);
            page.InsertBothValuesToInputFields(firstInput, secondInput);
            page.ClickGetTotalButton();
            page.VerifySumResult(result);
        }
    }
}
