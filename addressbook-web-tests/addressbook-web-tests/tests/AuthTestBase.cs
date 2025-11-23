using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests
{
    public class AuthTestBase : BaseTest
    {
        [SetUp]
        public void SetupLogin()
        {
            app = ApplicationManger.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
