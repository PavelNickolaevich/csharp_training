using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressBookTests.tests;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.CreateGroupIfNotExsist();

            List<GroupData> oldGroups = app.Groups.GetGroupsList();
   
            app.Groups.RemoveGroup(0);
          
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroups = app.Groups.GetGroupsList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
         
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
