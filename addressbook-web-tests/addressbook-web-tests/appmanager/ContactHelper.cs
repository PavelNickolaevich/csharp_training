using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManger manager) :base(manager) { }

        public ContactHelper CreateContatct(ContactData contactData)
        {
            GoToAddNewContact();
            FullContactInfo(contactData);
            SubmitContactInfo();

            return this;
        }

        public ContactHelper FullContactInfo(ContactData contactData)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactData.Middlename);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contactData.Nickname);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactData.DateInfoProperty.Day);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactData.DateInfoProperty.Month);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contactData.DateInfoProperty.Year);

            return this;
        }

        public ContactHelper GoToAddNewContact()
        {
            driver.FindElement(By.Id("header")).Click();
            driver.FindElement(By.LinkText("add new")).Click();

            return this;
        }
        public ContactHelper SubmitContactInfo()
        {
            driver.FindElement(By.Name("submit")).Click();

            return this;
        }
    }
}
