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
            app.Groups.RemoveGroup(1);
        }
    }
}
