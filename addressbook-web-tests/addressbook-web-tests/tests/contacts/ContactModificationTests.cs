using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests.contacts
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [SetUp]
        public void SetUp()
        {
            app.Contacts
                .CreateContactIfNotExsist();
        }
        [Test]
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

            app.NavigationHelper.LogOut();
        }
    }
}
