using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Page
{
    public class AlertPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";

        private IWebElement alertBoxButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement alertConfirmBoxButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement alertPromptBoxButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));

        public AlertPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AlertPage ClickOnAlertBoxButton()
        {
            alertBoxButton.Click();
            return this;
        }

        public AlertPage AcceptFirstAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }

        public AlertPage ClickOnComfirmBoxButton()
        {
            alertConfirmBoxButton.Click();
            return this;
        }

        public AlertPage DismissConfirmBoxAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            return this;
        }

        public AlertPage ClickOnPromptBoxButton()
        {
            alertPromptBoxButton.Click();
            return this;
        }

        public AlertPage AcceptPromptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys("Penktadienis!");
            alert.Accept();
            return this;
        }

    }
}
