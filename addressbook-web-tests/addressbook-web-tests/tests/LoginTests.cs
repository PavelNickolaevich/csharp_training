using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");

            app.Auth.Logout();
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));

        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            AccountData account = new AccountData("admin", "123456");

            app.Auth.Logout();
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }
    }
}
