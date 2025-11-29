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

        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("Ivan", "Ivanovich", "Ivanov", "Test", new ContactData.DateInfo("5", "May", "1988"));

            List<ContactData> oldContacts = app.Contacts.GetAllContacts();

            app.Contacts
                .CreateContact(contactData);

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

