using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Page
{
    public class SelectDropDownListPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";

        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement ResultTextAllSelectedElement => Driver.FindElement(By.CssSelector(".getall-selected"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        public SelectDropDownListPage(IWebDriver webdriver) : base(webdriver) { }

        public SelectDropDownListPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SelectDropDownListPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public SelectDropDownListPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public SelectDropDownListPage VerifyResult(string selectedDay)
        {
            Assert.AreEqual(ResultText + selectedDay, ResultTextElement.Text, $"Result is wrong, not {selectedDay}");
            return this;
        }

        public SelectDropDownListPage SelectFromMultipleDropdownAndClickFirstButton(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            //action.Click(FirstSelectedButton);
            FirstSelectedButton.Click();
            //action.Build().Perform();
            return this;
        }

        public SelectDropDownListPage ClickGetAllButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public SelectDropDownListPage CheckListedStates(List<string> selectedElements)
        {
            string result = ResultTextAllSelectedElement.Text;
            foreach (string selectedElement in selectedElements)
            {
                Assert.True(result.Contains(selectedElement),
                    $"Should be {selectedElement}, but was {result}");
            }
            return this;
        }

        public SelectDropDownListPage CheckFirstState(string selectedElement)
        {
            string result = ResultTextAllSelectedElement.Text;
            Assert.True(result.Contains(selectedElement),
                $"{selectedElement} is missing. {result}");
            return this;
        }

        public SelectDropDownListPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            foreach (IWebElement option in MultiDropDown.Options)
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    ClickMultipleBox(option);
                }
            return this;
        }

        private void ClickMultipleBox(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
    }
}
