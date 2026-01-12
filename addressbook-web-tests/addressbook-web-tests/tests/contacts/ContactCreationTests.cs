using addressbook_web_tests;
using Allure.NUnit;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using WebAddressBookTests.appmanager;
using WebAddressBookTests.tests;


namespace WebAddressBookTests
{
    [TestFixture]
    [AllureNUnit]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"TestDataContactXml.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                  File.ReadAllText(@"TestDataContactJson.json"));
        }


        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contactData)
        {
            //List<ContactData> oldContacts = app.Contacts.GetAllContacts();
            List<ContactData> oldContacts = ContactData.GetAllContactsFromDb();

            app.Contacts
                .CreateContact(contactData);

            int actualContacts = app.Contacts.GetContactsCount();
            Assert.AreEqual(oldContacts.Count + 1, actualContacts, "Количество контактов");

           // List<ContactData> newContacts = app.Contacts.GetAllContacts();
            List<ContactData> newContacts = ContactData.GetAllContactsFromDb();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

          //  app.NavigationHelper
                //.ReturnToHomePage()
             //   .LogOut();
        }
    }
}

