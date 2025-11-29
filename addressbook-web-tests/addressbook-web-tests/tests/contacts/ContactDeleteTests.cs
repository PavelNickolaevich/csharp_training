using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests.tests.contacts
{
    [TestFixture]
    public class ContactDeleteTests : AuthTestBase
    {

        [SetUp]
        public void SetUp()
        {
            app.Contacts
                .CreateContactIfNotExsist();
        }

        [Test]
        public void ContactDeleteTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetAllContacts();

            app.Contacts
              .RemoveContact(0);

            List<ContactData> newContacts = app.Contacts.GetAllContacts();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
