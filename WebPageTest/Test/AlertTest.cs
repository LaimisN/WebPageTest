using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.Test
{
    public class AlertTest : BaseTest
    {

        [Test]
        public static void AcceptFirstAlert()
        {
            alertPage.NavigateToDefaultPage()
                .ClickOnAlertBoxButton()
                .AcceptFirstAlert();
        }

        [Test]
        public static void DismissConfirmBoxAlert()
        {
            alertPage.NavigateToDefaultPage()
                .ClickOnComfirmBoxButton()
                .DismissConfirmBoxAlert();
        }

        [Test]
        public static void AcceptPromtBoxAlert()
        {
            alertPage.NavigateToDefaultPage()
                .ClickOnPromptBoxButton()
                .AcceptPromptAlert();
        }

    }
}
