using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{ 
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManger manger, string baseURL) : base(manger) { this.baseURL = baseURL; }
        public NavigationHelper GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");

            return this;
        }
        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();

            return this;
        }

        public NavigationHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.Navigate().GoToUrl(baseURL + "/addressbook");

            return this;
        }
        public NavigationHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();

            return this;
        }
    }
}
