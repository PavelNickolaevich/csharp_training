namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : BaseTest
    {

        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "white",
            };

            app.Groups.AddGroup(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
            //Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}
