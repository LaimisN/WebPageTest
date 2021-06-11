using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Test
{
    public class SebTest : BaseTest
    {
        [Test]
        public static void CalculateLoan()
        {
            sebPage.NavigateToDefaultPage()
                .AcceptCookies()
                .SwitchToIframe()
                .EnterIncome("1000")
                .SelectCity("Klaipeda")
                .ClickCalculateButton();
        }

    }
}
