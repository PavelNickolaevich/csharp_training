using NUnit.Framework;


namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected ApplicationManger app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManger();

            AccountData accountData = new AccountData("admin", "secret");

            app.NavigationHelper.GoToHomePage();
            app.Auth.Login(accountData);
        }

        [TearDown]
        public void TeardownTest()
        {
           app.Stop();
        }

    }
}
