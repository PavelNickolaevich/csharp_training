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
        [Test]
        public void ContactDeleteTest()
        {
            app.Contacts
                .RemoveContact(0);
        }
    }
}
