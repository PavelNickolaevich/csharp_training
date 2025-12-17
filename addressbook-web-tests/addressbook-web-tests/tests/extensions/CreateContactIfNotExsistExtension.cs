using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests.tests.contacts;
using static System.Net.Mime.MediaTypeNames;

namespace WebAddressBookTests.tests.extensions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CreateContactIfNotExsistExtension : TestActionAttribute
    {
        public override void BeforeTest(TestDetails testDetails)
        {
            if (testDetails.Fixture is ContactDeleteTests || testDetails.Fixture is ContactModificationTests)
            {
                var testClass = testDetails.Fixture;
                                                    
                if (testClass != null)
                {
                    var appField = typeof(ContactDeleteTests).GetField("app",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

                    if (appField != null)
                    {
                        ApplicationManger app = (ApplicationManger)appField.GetValue(testClass);
                        app.Contacts.CreateContactIfNotExsist();
                    }
                }
            } else
            {
                throw new Exception("Unexpected Fixture");
            }
        }
        public override ActionTargets Targets => ActionTargets.Test;
    }
}
