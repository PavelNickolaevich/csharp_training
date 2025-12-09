using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressBookTests.tests;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for(int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData groupData)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups
                   .CreateGroup(groupData);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroup = app.Groups.GetGroupsList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);
            
            app.NavigationHelper.LogOut();
        }

        //[Test]
        //public void EmptyCreationTest()
        //{
        //    GroupData groupData = new GroupData("", "", "");

        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups
        //        .CreateGroup(groupData);

        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

        //    List<GroupData> newGroup = app.Groups.GetGroupsList();
        //    oldGroups.Add(groupData);
        //    oldGroups.Sort();
        //    newGroup.Sort();
        //    Assert.AreEqual(oldGroups, newGroup);

        //    app.NavigationHelper.LogOut();
        //}

        //[Test]
        //public void BadNameCreationTest()
        //{
        //    GroupData groupData = new GroupData("a'a", "", "");

        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups
        //        .CreateGroup(groupData);

        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

        //    List<GroupData> newGroup = app.Groups.GetGroupsList();
        //    oldGroups.Sort();
        //    newGroup.Sort();
        //    Assert.AreEqual(oldGroups, newGroup);

        //    app.NavigationHelper.LogOut();
        //}
    }
}
