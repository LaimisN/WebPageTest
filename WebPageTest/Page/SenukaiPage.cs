using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Page
{
    public class SenukaiPage : BasePage
    {
        private const string PageAddress = "https://www.senukai.lt/";

        public SenukaiPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public SenukaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SenukaiPage AcceptCookie()
        {
            Cookie myCookie = new Cookie("CookieConsent"
                , "{stamp:%271WoaYbqGv7/9jhUoL8tlURkM63pL9O5xHkdpm+nt2u3x5CUZ2X13MQ==%27%2Cnecessary:false%2Cpreferences:false%2Cstatistics:true%2Cmarketing:false%2Cver:1%2Cutc:1621009131736%2Cregion:%27lt%27}"
                , "www.senukai.lt"
                , "/"
                , DateTime.Now.AddDays(5));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();

            return this;
        }
    }
}
