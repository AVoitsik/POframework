using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordPressTests
{
    [TestClass]
    public class LoginTests : WordpressTest
    {

        [TestMethod]
        public void Ehealth_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt,"Failed to login");
        }

    }
}
