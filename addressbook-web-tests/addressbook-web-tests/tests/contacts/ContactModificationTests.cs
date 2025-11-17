using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests.contacts
{
    [TestFixture]
    public class ContactModificationTests : BaseTest
    {
        [Test]
        public void ContactModificationTest() {

            ContactData contactData = new ContactData("IvanTest", "Petrovich", "Vasin", "Tes22t", new ContactData.DateInfo("10", "May", "1989"));

            app.Contacts.ModificationGroup(1, contactData, 1);
        }
    }
}
