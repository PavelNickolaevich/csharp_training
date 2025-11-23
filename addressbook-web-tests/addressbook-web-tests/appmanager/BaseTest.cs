using NUnit.Framework;


namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected ApplicationManger app;

        [SetUp]
        public void SetupApllicationManager()
        {
            app = ApplicationManger.GetInstance();
    
        }
    }
}
