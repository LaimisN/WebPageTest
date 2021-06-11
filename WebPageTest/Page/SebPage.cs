using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Page
{
    public class SebPage : BasePage
    {
        private const string PageAddress = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";

        private IWebElement cookiesButton => Driver.FindElement(By.CssSelector(".main.accept-selected"));
        private IWebElement incomeInput => Driver.FindElement(By.Id("income"));
        private IWebElement calculateButton => Driver.FindElement(By.Id("calculate"));
        private SelectElement citySelect => new SelectElement(Driver.FindElement(By.Id("city")));


        public SebPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public SebPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SebPage AcceptCookies()
        {
            cookiesButton.Click();
            return this;
        }

        public SebPage EnterIncome(string income)
        {
            incomeInput.Clear();
            incomeInput.SendKeys(income);
            return this;
        }

        public SebPage SwitchToIframe()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }

        public SebPage SelectCity(string value)
        {
            citySelect.SelectByValue(value);
            return this;
        }

        public SebPage ClickCalculateButton()
        {
            calculateButton.Click();
            return this;
        }



    }
}
