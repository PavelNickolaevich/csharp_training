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

            List<GroupData> newGroup = app.Groups.GetGroupsList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroup);
            Assert.AreEqual(oldGroups.Count, newGroup.Count);
        }
    }
}
