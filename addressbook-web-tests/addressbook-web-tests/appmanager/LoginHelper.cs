using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests;

namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManger manger) : base(manger) { }
        public void Login(AccountData accountData)
        {
            if(IsLoggedIn())
            {
                if(IsLoggedIn(accountData))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.Id("container")).Click();
            Type(By.Name("user"), accountData.Username);
            Type(By.Name("pass"), accountData.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text 
                == "(" + account.Username + ")";
                 
        }

        public void Logout()
        {
            if(IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
           
        }
    }
}
