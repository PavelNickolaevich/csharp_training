using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WebAddressBookTests;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private By allEntityContacts = By.XPath("//tr[@name='entry']");

        public ContactHelper(ApplicationManger manager) :base(manager) { }

        public ContactHelper CreateContact(ContactData contactData)
        {
            GoToAddNewContact();

            FullContactInfo(contactData);
            SubmitContactInfo();
            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        public ContactHelper CreateContactWithAddressEmailPhones(ContactData contactData)
        {
            GoToAddNewContact();

            FillAddressEmailPhone(contactData);
            SubmitContactInfo();
            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        public ContactHelper ModificationGroup(int indexContact, ContactData contactData, int numBtn)
        {
            manager.NavigationHelper.GoToHomePage();

            CreateContactIfNotExsist();

            SelectModifyContact(indexContact);
            FullContactInfo(contactData);
            UpdateContactInfo(numBtn);

            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        public ContactHelper ModificationGroupByContactId(string contacId, ContactData contactData, int numBtn)
        {
            manager.NavigationHelper.GoToHomePage();

            CreateContactIfNotExsist();

            SelectModifyContactById(contacId);
            FullContactInfo(contactData);
            UpdateContactInfo(numBtn);

            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        public ContactHelper RemoveContact(int indexContact)
        {
            manager.NavigationHelper.GoToHomePage();

           // CreateContactIfNotExsist();

            SelectContactByIndex(indexContact);
            DeleteContact();

            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        public ContactHelper RemoveContact(ContactData contact)
        {
            manager.NavigationHelper.GoToHomePage();

            SelectContactById(contact.Id);
            DeleteContact();

            manager.NavigationHelper.ReturnToHomePage();

            return this;
        }

        private ContactHelper SelectContactById(string contactId)
        {
            driver.FindElement(By.XPath($"//input[@type='checkbox' and @value='"+contactId+"']")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.Name("delete")).Click();
            contactsHash = null;
            return this;
        }

        public ContactHelper SelectContactByIndex(int indexContact)
        {
            driver.FindElements(By.XPath($"//input[@type='checkbox']"))[indexContact].Click();
            return this;
        }


        public ContactHelper FillAddressEmailPhone(ContactData contactData)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contactData.Address);

            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contactData.HomePhone);

            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactData.MobilePhone);

            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contactData.WorkPhone);

            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contactData.Email);

            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contactData.Email2);

            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contactData.Email3);

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
            contactsHash = null;
            return this;
        }

        public ContactHelper UpdateContactInfo(int numBtn)
        {
            driver.FindElements(By.XPath($"//input[@name='update']"))[numBtn].Click();
            contactsHash = null;
            return this;
        }

        public ContactHelper SelectModifyContact(int indexContact)
        {
            driver.FindElements(By.XPath($"//img[@title='Edit']"))[indexContact].Click();
            return this;
        }

        public ContactHelper SelectModifyContactById(string contactId)
        {
            driver.FindElement(By.XPath($"//a[@href='edit.php?id="+contactId+"']")).Click();
            return this;
        }

        public ContactHelper SelectDetailsContact(int indexContact)
        {
            driver.FindElements(By.XPath($"//img[@title='Details']"))[indexContact].Click();
            return this;
        }



        public void CreateContactIfNotExsist()
        {
            ContactData contactData = new ContactData("Ivan", "Ivanovich", "Ivanov", "Test", new ContactData.DateInfo("5", "May", "1988"));
            if (GetContactsCount() == 0)
            {
                CreateContact(contactData);
             //   manager.NavigationHelper.ReturnToHomePage();
            }
        }

        public int GetContactsCount()
        {
            return driver.FindElements(allEntityContacts).Count;
        }


        public List<ContactData> contactsHash = null;

        public List<ContactData> GetAllContacts() {

            if (contactsHash == null)
            {
                contactsHash = new List<ContactData>();
                manager.NavigationHelper.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath($"//tr[@name='entry']"));

                foreach (IWebElement element in elements)
                {
                    string lastname = element.FindElements(By.TagName("td"))[1].Text;
                    string firstname = element.FindElements(By.TagName("td"))[2].Text;
                    contactsHash.Add(new ContactData(firstname, lastname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }

            return new  List<ContactData>(contactsHash);
        }

        public ContactData getContactDataFromTable(int index)
        {
            manager.NavigationHelper.GoToHomePage();
            IWebElement element = driver.FindElements(By.XPath($"//tr[@name='entry']"))[index];
            List<IWebElement> elements = driver.FindElements(By.XPath($"//tr[@name='entry']"))[index]
                .FindElements(By.TagName("td")).ToList();

            string lastname = elements[1].Text;
            string firstname = elements[2].Text;
            string address = elements[3].Text;
            string allEmail = elements[4].Text;
            string allPhone = elements[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllEmail = allEmail,
                AllPhones = allPhone,
            };

        }

        public ContactData getContactInformationFromEditForm(int index)
        {
            manager.NavigationHelper.GoToHomePage();
            SelectModifyContact(index);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                HomePhone = homePhome,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        public string getContactStringInformationFromEditForm(int index)
        {
            manager.NavigationHelper.GoToHomePage();
            SelectModifyContact(index);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

         //   return $"{firstname} {FormatLastName(lastname)}{FormatAddress(address)}{FormatPhone("H", homePhone)}{FormatPhone("M", mobilePhone)}{FormatPhone("W", workPhone)}{FormatEmail(email)}{FormatEmail(email2)}{FormatEmail(email3)}".Trim();
            return FormatContact(firstname, lastname, address, homePhone, mobilePhone, workPhone, email, email2, email3);

        }

        public string FormatContact(
            string firstname,
            string lastname,
            string address,
            string homePhone,
            string mobilePhone,
            string workPhone,
            string email,
            string email2,
            string email3
            )
        {
            var result = new StringBuilder();

            // Имя и фамилия
            result.Append($"{firstname} {FormatLastName(lastname)}");

            // Адрес
            if (!string.IsNullOrEmpty(address)) {
                result.Append($"\r\n{address}\r\n\r\n");
             }
            else { 
                result.Append("\r\n\r\n");
            }

            // Телефоны
            var phones = new List<string>();
            if (!string.IsNullOrEmpty(homePhone))
                phones.Add($"H: {homePhone}");
            if (!string.IsNullOrEmpty(mobilePhone))
                phones.Add($"M: {mobilePhone}");
            if (!string.IsNullOrEmpty(workPhone))
                phones.Add($"W: {workPhone}");

            if (phones.Count > 0)
            {
                result.Append(string.Join("\r\n", phones));
                result.Append("\r\n\r\n");
            }

            // Email
            var emails = new List<string>();
            if (!string.IsNullOrEmpty(email))
                emails.Add(email);
            if (!string.IsNullOrEmpty(email2))
                emails.Add(email2);
            if (!string.IsNullOrEmpty(email3))
                emails.Add(email3);

            if (emails.Count > 0)
            {
                result.Append(string.Join("\r\n", emails));
                result.Append("\r\n");
            }
            return result.ToString().Trim();
        }

        private string FormatLastName(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                return line;
            }
            return string.Empty;
        }

        private string FormatAddress(string line)
        {
            if (!string.IsNullOrEmpty(line))
            {
                return "\r\n" + line + "\r\n\r\n";
            }
            return string.Empty + "\r\n\r\n";
        }

        private string FormatPhone(string prefix, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                return $"{prefix}: {phoneNumber}\r\n";
            }
            return string.Empty;
        }

        private string FormatEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return email + "\r\n";
            }
            return string.Empty;
        }

        public string GetContactDataInformationFromDeatailsForm(int index)
        {

            manager.NavigationHelper.GoToHomePage();

            SelectDetailsContact(index);

            IWebElement content = driver.FindElement(By.Id("content"));
            string сontentText = content.Text;

            return сontentText;

         //   return Regex.Replace(сontentText, @"(\r\n|M:|W:|H:|\s)", "").Trim();

        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.NavigationHelper.GoToHomePage();
            CleanGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.NavigationHelper.GoToHomePage();
            CleanGroupFilter();
            SelectGroup(group.Name);
            SelectContact(contact.Id);
            CommitDeleteContactFromGrouoGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitDeleteContactFromGrouoGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectContact(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();     
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);

        }

        public void CleanGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}
