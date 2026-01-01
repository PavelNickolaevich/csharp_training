using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
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

            Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count - 1));
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.That(newGroups, Is.EqualTo(oldGroups));

        }
    }
}
