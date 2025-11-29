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
        [Test]
        public void GroupCreationTest()
        {
            GroupData groupData = new GroupData("test", "test", "test");

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups
                   .CreateGroup(groupData);

            List<GroupData> newGroup = app.Groups.GetGroupsList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);
            app.NavigationHelper.LogOut();
        }

        [Test]
        public void EmptyCreationTest()
        {
            GroupData groupData = new GroupData("", "", "");

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups
                .CreateGroup(groupData);

            List<GroupData> newGroup = app.Groups.GetGroupsList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);

            app.NavigationHelper.LogOut();
        }

        [Test]
        public void BadNameCreationTest()
        {
            GroupData groupData = new GroupData("a'a", "", "");

            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            app.Groups
                .CreateGroup(groupData);
            
            List<GroupData> newGroup = app.Groups.GetGroupsList();
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);

            app.NavigationHelper.LogOut();
        }
    }
}
