using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()

        {
            GroupData newGroupData = new GroupData("Modify", null, null);

            app.Groups.CreateGroupIfNotExsist();

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            GroupData oldGroup = oldGroups[0];

            app.Groups.Modify(0, newGroupData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            List<GroupData> newGroup = app.Groups.GetGroupsList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);

            foreach (GroupData group in newGroup)
            {
                if (group.Id == oldGroup.Id)
                {
                    Assert.AreEqual(newGroupData.Name, group.Name);
                }
            }

        }
    }
}
