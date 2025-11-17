using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ApplicationManger
    {

        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManger() {

            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();

            this.loginHelper = new LoginHelper(this);
            this.navigationHelper = new NavigationHelper(this, baseURL);
            this.groupHelper = new GroupHelper(this);
            this.contactHelper = new ContactHelper(this);
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }

        public IWebDriver Driver { get { return driver; } }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

    }
}
