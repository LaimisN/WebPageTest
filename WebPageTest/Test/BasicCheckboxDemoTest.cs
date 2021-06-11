using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationSolution.Page;

namespace AutomationSolution.Test
{
    public class BasicCheckboxDemoTest : BaseTest
    {

        [Order(1)]
        [Test]
        public static void SingleCheckBoxTest()
        {
            basicCheckboxDemoPage.NavigateToDefaultPage()
                .CheckSingleCheckBox()
                .AssertSingleCheckBoxDemoSuccessMessage()
                .UnCheckSingleCheckBox();

        }

        [Order(2)]
        [Test]
        public static void MultipleCheckBoxTest()
        {
            basicCheckboxDemoPage.NavigateToDefaultPage()
                .CheckAllMultipleCheckBoxes()
                .AssertButtonName("Uncheck All");
        }

        [Order(3)]
        [Test]
        public static void UncheckMultipleCheckBoxesTest()
        {
            basicCheckboxDemoPage.NavigateToDefaultPage()
                .CheckAllMultipleCheckBoxes()
                .ClickGroupButton()
                .AssertMultipleCheckBoxesUnchecked();
        }

        [Order(4)]
        [Test]
        public static void ThisIsDemoTest()
        {
            basicCheckboxDemoPage.NavigateToDefaultPage()
                .CheckAllMultipleCheckBoxes()
                .ClickGroupButton()
                .AssertMultipleCheckBoxesUnchecked();
        }
    }
}
