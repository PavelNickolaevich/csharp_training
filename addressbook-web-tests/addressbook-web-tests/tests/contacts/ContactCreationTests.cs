using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebAddressBookTests.tests;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomDataContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {

             ContactData.DateInfo dateInfo = GenerateDate();

            contacts.Add(
                    new ContactData(
                        GenerateName(5),
                        GenerateName(5),
                        GenerateName(5),
                        GenerateName(5),
                         new ContactData.DateInfo(dateInfo.Day, dateInfo.Month, dateInfo.Year)));
            }
            return contacts;
        }

     
        [Test, TestCaseSource("RandomDataContactDataProvider")]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> oldContacts = app.Contacts.GetAllContacts();

            app.Contacts
                .CreateContact(contactData);

            int actualContacts = app.Contacts.GetContactsCount();
            Assert.AreEqual(oldContacts.Count + 1, actualContacts, "Количество контактов");

            List<ContactData> newContacts = app.Contacts.GetAllContacts();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.NavigationHelper
                //.ReturnToHomePage()
                .LogOut();
        }
    }
}

