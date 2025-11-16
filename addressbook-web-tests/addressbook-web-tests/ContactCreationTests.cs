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
            AccountData accountData = new AccountData("admin", "secret");

            ContactData contactData = new ContactData("Ivan", "Ivanovich", "Ivanov", "Test", new ContactData.DateInfo("5", "May", "1988"));

            GoToHomePage();
            Login(accountData);
            GoToAddNewContact();
            FullContactInfo(contactData);
            SubmitContactInfo();
            ReturnToHomePage();
            LogOut();
        }

    }
}

