using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            applicationManager.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);

            Assert.IsTrue(applicationManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            applicationManager.Auth.Logout();

            AccountData account = new AccountData("admin", "12345");
            applicationManager.Auth.Login(account);

            Assert.IsFalse(applicationManager.Auth.IsLoggedIn(account));
        }
    }
}
