using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupDeleteTests : BaseTest
    {
        [Test]
        public void TestGroupDelete()
        {
            app.Groups.CreateGroupIfNotExsist();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.DeleteGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();

            // Assert.AreEqual(oldGroups, newGroups);
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }
    }
}
