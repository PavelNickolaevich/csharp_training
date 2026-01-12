using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        private string loginBtn = "//input[@type='submit']";
        public LoginHelper(ApplicationManger manger) : base(manger)
        {
        }

        public void Login(AccountData accountData)
        {
            Type(By.Id("username"), accountData.Name);
            driver.FindElement(By.XPath(loginBtn)).Click();
            Type(By.Id("password"), accountData.Password);
            driver.FindElement(By.XPath(loginBtn)).Click();
        }
    }
}
