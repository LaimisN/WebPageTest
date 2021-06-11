using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationSolution.Page
{
    public class BasicCheckboxDemoPage : BasePage
    {
        private const string urlPage = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private const string successMessage = "Success - Check box is checked";

        private IWebElement singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));

        private IWebElement singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));

        private IReadOnlyCollection<IWebElement> multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));

        private IWebElement checkAllButton => Driver.FindElement(By.Id("check1"));

        public BasicCheckboxDemoPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public BasicCheckboxDemoPage NavigateToDefaultPage()
        {
            if (Driver.Url != urlPage)
            {
                Driver.Url = urlPage;
            }
            return this;
        }

        public BasicCheckboxDemoPage CheckSingleCheckBox()
        {
            if (!singleCheckBox.Selected)
            {
                singleCheckBox.Click();
            }
            return this;
        }

        public BasicCheckboxDemoPage UnCheckSingleCheckBox()
        {
            if (singleCheckBox.Selected)
            {
                singleCheckBox.Click();
            }
            return this;
        }

        public BasicCheckboxDemoPage AssertSingleCheckBoxDemoSuccessMessage()
        {

            Assert.AreEqual(successMessage, singleCheckBoxMessage.Text, "tekstas nesutampa!");
            return this;
        }

        public BasicCheckboxDemoPage AssertSingleCheckBoxDemoSuccessMessageWithWait()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(successMessage, singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }


        public BasicCheckboxDemoPage CheckAllMultipleCheckBoxes()
        {
            UnCheckSingleCheckBox();
            foreach (IWebElement singleCheckbox in multipleCheckBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
            return this;
        }

        public BasicCheckboxDemoPage AssertButtonName(string expectedName)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(checkAllButton, expectedName));
            Assert.AreEqual(expectedName, checkAllButton.GetAttribute("value"), "Wrong button label");
            return this;
        }


        public BasicCheckboxDemoPage ClickGroupButton()
        {
            checkAllButton.Click();
            return this;
        }

        public BasicCheckboxDemoPage AssertMultipleCheckBoxesUnchecked()
        {
            foreach (IWebElement singleCheckbox in multipleCheckBoxes)
            {
                Assert.Multiple(() =>
                {
                    Assert.False(!singleCheckbox.Selected, "A One of checkboxes is still checked!");
                    Assert.IsTrue(!singleCheckbox.Selected, "B One of checkboxes is still checked!");
                    Assert.That(singleCheckbox.Selected, "C One of checkboxes is still checked!");
                });
            }

            return this;
        }

    }
}
