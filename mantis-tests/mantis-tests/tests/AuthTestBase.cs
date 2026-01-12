using mantis_tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class AuthTestBase : BaseTest
{
        [SetUp]
        public void SetupLogin()
        {
            AccountData accountData = new AccountData
            {
                Name = "administrator",
                Password = "root",
            };

            app = ApplicationManger.GetInstance();
            app.LoginHelper.Login(accountData);
        }
    }
}
