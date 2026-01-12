
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
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManger
    {

        protected IWebDriver driver;
        protected StringBuilder verificationErrors;

        public RegistrationHelper RegistrationHelper { get; private set; } 

        public MenuHelper MenuHelper { get; private set; }
        public FtpHelper FtpHelper { get; private set; } 
        public LoginHelper LoginHelper { get; private set; }

        public NotifyContentPage NotifyContentPage { get; private set; }

        public ManageHelper ManageHelper { get; private set; } 

        protected string baseURL;
       
        private static ThreadLocal<ApplicationManger> app = new ThreadLocal<ApplicationManger>();

        private ApplicationManger() {

            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
            RegistrationHelper = new RegistrationHelper(this);
            FtpHelper = new FtpHelper(this);
            ManageHelper = new ManageHelper(this);
            MenuHelper = new MenuHelper(this);
            LoginHelper = new LoginHelper(this);
            NotifyContentPage = new NotifyContentPage(this);

        }
       // captcha
        ~ApplicationManger()
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

        public static ApplicationManger GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManger newInstance = new ApplicationManger();
                newInstance.driver.Url = "http://localhost/mantisbt-2.20.0/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        
        public IWebDriver Driver { get { return driver; } }

    }
}
