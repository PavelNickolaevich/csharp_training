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
    public class ContactDeleteTests : ContactTestBase
    {

        [Test]
        [CreateContactIfNotExsistExtension]
        public void ContactDeleteTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetAllContacts();

            app.Contacts
              .RemoveContact(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        [CreateContactIfNotExsistExtension]
        public void ContactDeleteWithDataBaseTest()
        {
            List<ContactData> oldContacts = ContactData.GetAllContactsFromDb();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts
              .RemoveContact(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllContactsFromDb();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
