using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : BaseTest
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData groupData = new GroupData("Modify", "Modify", "Modify");

            app.Groups.Modify(1, groupData);

        }
    }
}
