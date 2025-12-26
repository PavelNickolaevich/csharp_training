using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests.tests.contacts;

namespace WebAddressBookTests.tests.extensions
{
    public class CreateGroupWithContactExtension : TestActionAttribute
    {
        public override void BeforeTest(TestDetails testDetails)
        {

            GroupData group = new GroupData(BaseTest.GenerateName(7))
            {
                Header = BaseTest.GenerateName(7),
                Footer = BaseTest.GenerateName(7)
            };
            ContactData contact = new ContactData(BaseTest.GenerateName(7), "Ivanovich", "Ivanov", "Test", new ContactData.DateInfo("5", "May", "1988"));


            if (testDetails.Fixture is DeleteContactFromGroupTest)
            {
                var testClass = testDetails.Fixture;

                if (testClass != null)
                {
                    var appField = typeof(DeleteContactFromGroupTest).GetField("app",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

                    if (appField != null)
                    {
                        ApplicationManger app = (ApplicationManger)appField.GetValue(testClass);
                        app.Groups.CreateGroup(group);
                        app.Contacts.CreateContact(contact);
                        contact = ContactData.GetContactByName(contact.Firstname);
                        app.Contacts.AddContactToGroup(contact, group);
   
                        TestContext.CurrentContext.Test.Properties.Add("CreatedGroup", group);
                        TestContext.CurrentContext.Test.Properties.Add("CreatedContact", contact);
                    }
                }
            }
            else
            {
                throw new Exception("Unexpected Fixture");
            }
        }
        public override ActionTargets Targets => ActionTargets.Test;
    }
}
