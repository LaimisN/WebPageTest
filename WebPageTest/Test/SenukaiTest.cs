using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Test
{
    public class SenukaiTest : BaseTest
    {

        [Test]
        public static void AcceptCookies()
        {
            senukaiPage.NavigateToDefaultPage()
                .AcceptCookie();
        }
    }
}
