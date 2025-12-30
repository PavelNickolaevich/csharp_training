using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class GroupCreationTests : BaseTest
    {

        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test1",
            };

            app.Groups.AddGroup(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

           // Assert.AreEqual(oldGroups, newGroups);
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
