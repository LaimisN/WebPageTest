using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSolution
{
    public class NunitDemo
    {

        [Test]
        public static void TestIf4ISEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even!");
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(23, currentTime.Hour, "Dabar ne 23 valanda");
        }

        [Test]
        public static void Wait5Seconds()
        {
            Thread.Sleep(5000);
        }
    }
}

