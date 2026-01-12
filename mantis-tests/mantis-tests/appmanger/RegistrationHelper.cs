using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManger manger) : base(manger) { }

        public void Register(AccountData accountData)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistartionForm(accountData);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//a[@class='back-to-login-link pull-left']")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        private void FillRegistartionForm(AccountData accountData)
        {
            driver.FindElement(By.Name("username")).SendKeys(accountData.Name);
            driver.FindElement(By.Name("email")).SendKeys(accountData.Password);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.20.0/login_page.php";
        }
    }
}
