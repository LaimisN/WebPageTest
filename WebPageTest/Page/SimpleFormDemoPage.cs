using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Page
{
    public class SimpleFormDemoPage
    {
        private static IWebDriver _driver;

        private IWebElement enterMessageInput => _driver.FindElement(By.Id("user-message"));
        private IWebElement showMessageButton => _driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement singleInputResult => _driver.FindElement(By.Id("display"));
        private IWebElement firstInputField => _driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => _driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => _driver.FindElement(By.XPath("//*[@id='gettotal']/button"));
        private IWebElement actualResult => _driver.FindElement(By.Id("displayvalue"));


        public SimpleFormDemoPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertTextToSingleInputField(string text)
        {
            enterMessageInput.Clear();
            enterMessageInput.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            showMessageButton.Click();
        }

        public void VerifySingleInputField(string expectedResult)
        {
            Assert.AreEqual(expectedResult, singleInputResult.Text, "Tests is not equals!");
        }

        public void InsertFirstInputField(string firstInput)
        {
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);
        }

        public void InsertSecondInputField(string secondInput)
        {
            secondInputField.Clear();
            secondInputField.SendKeys(secondInput);
        }

        public void InsertBothValuesToInputFields(string firstInput, string secondInput)
        {
            InsertFirstInputField(firstInput);
            InsertSecondInputField(secondInput);
        }

        public void ClickGetTotalButton()
        {
            getTotalButton.Click();
        }

        public void VerifySumResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, actualResult.Text, "Result is not correct!");
        }
    }
}
