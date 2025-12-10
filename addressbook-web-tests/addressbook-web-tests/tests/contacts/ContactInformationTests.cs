using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests.contacts
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactCheckEditInfoTest()
        {
            //Random random = new Random();
            //string uniqueName = $"name_{random.Next(1, 100000000)}";
            //ContactData contact = new ContactData(
            //        uniqueName,
            //        uniqueName,
            //        "Москва 4пукпукрукрн4н4н4",
            //        "5353536",
            //        "3435-66565",
            //        "5(464)66666",
            //        "11@g.com",
            //        "12@g.com",
            //        "12@g.com"
            //        );
            //app.Contacts.CreateContactWithAddressEmailPhones(contact);

            //List<ContactData> contacts = app.Contacts.GetAllContacts();
           
            //int index = contacts.IndexOf(contact);
            ContactData contactFromTable = app.Contacts.getContactDataFromTable(0);
            ContactData contactFromEditForm = app.Contacts.getContactInformationFromEditForm(0);

            Assert.AreEqual(contactFromTable,  contactFromEditForm);
            Assert.AreEqual(contactFromTable.Address,  contactFromEditForm.Address);
            Assert.AreEqual(contactFromTable.AllEmail,  contactFromEditForm.AllEmail);
            Assert.AreEqual(contactFromTable.AllPhones,  contactFromEditForm.AllPhones);
        }


        [Test]
         public void ContactCheckDetailInfoTest()
        {

            Random random = new Random();
            string uniqueName = $"name_{random.Next(1, 100000000)}";
            ContactData contact = new ContactData(
                    uniqueName,
                    uniqueName,
                    "Москва 4пукпукрукрн4н4н4",
                    "5353536",
                    "3435-66565",
                    "5(464)66666",
                    "11@g.com",
                    "12@g.com",
                    "12@g.com"
                    );
            app.Contacts.CreateContactWithAddressEmailPhones(contact);

            List<ContactData> contacts = app.Contacts.GetAllContacts();

            int index = contacts.IndexOf(contact);
            ContactData contactFromDetailFor = app.Contacts.getContactDataInformationFromDeatailsForm(0);
            ContactData contactFromEditForm = app.Contacts.getContactInformationFromEditForm(0);

            Assert.AreEqual(contactFromDetailFor, contactFromEditForm);
            Assert.AreEqual(contactFromDetailFor.Address, contactFromEditForm.Address);
            Assert.AreEqual(contactFromDetailFor.AllEmail, contactFromEditForm.AllEmail);
            Assert.AreEqual(contactFromDetailFor.AllPhones, contactFromEditForm.AllPhones);

        }    
    }
}
