using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : BaseTest
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("Ivan", "Ivanovich", "Ivanov", "Test", new ContactData.DateInfo("5", "May", "1988"));

            app.Contacts
                .CreateContatct(contactData);
            app.NavigationHelper
                .ReturnToHomePage()
                .LogOut();
           
        }

    }
}

