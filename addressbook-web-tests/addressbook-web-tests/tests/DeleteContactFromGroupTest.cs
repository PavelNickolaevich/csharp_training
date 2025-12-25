using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests.tests.extensions;

namespace WebAddressBookTests.tests
{
    public class DeleteContactFromGroupTest : AuthTestBase
    {

        [Test]
        [CreateGroupWithContactExtension]
        public void DeleleteContactFromGroupTest()
        {
            GroupData group = TestContext.CurrentContext.Test.Properties["CreatedGroup"] as GroupData;
           // ContactData contact = TestContext.CurrentContext.Test.Properties["CreatedContact"] as ContactData;
           // GroupData group = GroupData.GetGroupsFromDb()[0];
            GroupData groupDb = GroupData.GetGroupsByNameFromDb(group.Name);
            List<ContactData> oldList = groupDb.GetContactsFromDb();
            ContactData contact = oldList[0]; 

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContactsFromDb();
            newList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
