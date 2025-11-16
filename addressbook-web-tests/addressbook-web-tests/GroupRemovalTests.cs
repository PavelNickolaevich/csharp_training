using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : BaseTest
    {
        [Test]
        public void GroupRemovalTest()
        {
            AccountData accountData = new AccountData("admin", "secret");

            GoToHomePage();
            Login(accountData);
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
        }
    }
}
