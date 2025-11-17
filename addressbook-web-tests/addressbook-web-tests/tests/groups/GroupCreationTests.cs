using addressbook_web_tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupCreationTests : BaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData groupData = new GroupData("test", "test", "test");

            app.Groups
                   .CreateGroup(groupData);
            app.NavigationHelper.LogOut();
        }

        [Test]
        public void EmptyCreationTest()
        {
            GroupData groupData = new GroupData("", "", "");

            app.Groups
                .CreateGroup(groupData);
            app.NavigationHelper.LogOut();
        }
    }
}
