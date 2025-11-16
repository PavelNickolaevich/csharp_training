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
            AccountData accountData = new AccountData("admin", "secret");
            GroupData groupData = new GroupData("test", "test", "test");

            GoToHomePage();
            Login(accountData);
            GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        }
    }
}
