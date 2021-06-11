using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution
{
    class InputDemo
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(x => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }


        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        public static void TestSumBlock(string firstInput, string secondInput, string result)
        {
            IWebElement firstInputField = _driver.FindElement(By.Id("sum1"));
            IWebElement secondInputField = _driver.FindElement(By.Id("sum2"));
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);
            secondInputField.Clear();
            secondInputField.SendKeys(secondInput);
            IWebElement getTotalButton = _driver.FindElement(By.XPath("//*[@id='gettotal']/button"));
            getTotalButton.Click();
            IWebElement actualResult = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, actualResult.Text, "Sum is Incorrect");
        }

    }
}
