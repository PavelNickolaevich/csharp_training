using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests.appmanager;
using WebAddressBookTests.tests.extensions;

namespace WebAddressBookTests.tests.contacts
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {

        [Test]
        [CreateContactIfNotExsistExtension]
        public void ContactModificationTest() {

            ContactData contactData = new ContactData("IvanTest", "Petrovich", "Vasin", "Tes22t", new ContactData.DateInfo("10", "May", "1989"));

            List<ContactData> oldContacts = app.Contacts.GetAllContacts();
            ContactData oldContact = oldContacts[0];

            app.Contacts.ModificationGroup(0, contactData, 1);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount(), "Количество записей не соответствует");

            List<ContactData> newContacts = app.Contacts.GetAllContacts();
            oldContacts[0] = contactData;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if(oldContact.Id == contact.Id)
                {
                    Assert.AreEqual(contactData.Firstname, contact.Firstname);
                    Assert.AreEqual(contactData.Lastname, contact.Lastname);
                }
            }

          //  app.NavigationHelper.LogOut();
        }


        [Test]
        [CreateContactIfNotExsistExtension]
        public void ContactModificationWithDataBaseTest()
        {
            ContactData contactData = new ContactData("IvanTest1", "Petrovich1", "Vasin1", "Tes22t", new ContactData.DateInfo("11", "May", "1990"));

            List<ContactData> oldContacts = ContactData.GetAllContactsFromDb();
            ContactData oldContact = oldContacts[0];

            app.Contacts.ModificationGroupByContactId(oldContact.Id, contactData, 1);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount(), "Количество записей не соответствует");

            List<ContactData> newContacts = ContactData.GetAllContactsFromDb();
            oldContacts[0] = contactData;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (oldContact.Id == contact.Id)
                {
                    Assert.AreEqual(contactData.Firstname, contact.Firstname);
                    Assert.AreEqual(contactData.Lastname, contact.Lastname);
                }
            }

           // app.NavigationHelper.LogOut();
        }
    }
}
