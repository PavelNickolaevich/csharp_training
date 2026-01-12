namespace mantis_tests;
using NUnit.Framework;

[TestFixture]
public class AccountCreationTest : BaseTest
{

    [OneTimeSetUp]
    public void SetUpConfig()
    {
        app.FtpHelper.BackUpFile("/config_inc.php");
        using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
        {
            app.FtpHelper.UploadFile("/config_inc.php", localFile);
        }
    }


    [Test]
    public void TestAccountRegestration()
    {
        AccountData accountData = new AccountData
        {
            Name = "TestUser",
            Password = "123",
            Email = "testtest@gmail.com"
        };

        app.RegistrationHelper.Register(accountData);
    }

    [OneTimeTearDown]
    public void RestoreConfig()
    {
        app.FtpHelper.RestoreBackupFile("/config_defaults_inc.php");
      
    }

}
