using AutomationSolution.Driver;
using AutomationSolution.Page;
using AutomationSolution.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomationSolution.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static BasicCheckboxDemoPage basicCheckboxDemoPage;
        public static SelectDropDownListPage selectDropDownPage;
        public static SenukaiPage senukaiPage;
        public static AlertPage alertPage;
        public static SebPage sebPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            basicCheckboxDemoPage = new BasicCheckboxDemoPage(driver);
            selectDropDownPage = new SelectDropDownListPage(driver);
            senukaiPage = new SenukaiPage(driver);
            alertPage = new AlertPage(driver);
            sebPage = new SebPage(driver);

        }

        [TearDown]
        public static void TearDownAttribute()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }

    }
}
