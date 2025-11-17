using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManger manager;

        public HelperBase(ApplicationManger manger) { this.driver = manger.Driver; this.manager = manger; }
    }
}