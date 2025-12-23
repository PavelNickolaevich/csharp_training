using addressbook_web_tests;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using WebAddressBookTests.appmanager;
using WebAddressBookTests.model;
using WebAddressBookTests.tests;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for(int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCscFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"TestDataGroup.csv");

           foreach (string l in lines)
            {
               string[]parts =  l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
           return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"TestDataGroupXml.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
          return  JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"TestDataGroupJson.json"));
        }
        //public static IEnumerable<GroupData> GroupDataFromExcelFile()
        //{
        //    List<GroupData> groups = new List<GroupData>();
        //    Excel.Application app = new Excel.Application();
        //    Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"TestDataGroupXlsm.xlsx"));
        //    Excel.Worksheet sheet = wb.ActiveSheet;
        //    Excel.Range range = sheet.UsedRange;

        //    for (int i = 1; i <= range.Rows.Count; i++)
        //    {
        //        new GroupData()
        //        {
        //            Name = range.Cells[i, 1].Value,
        //            Header = range.Cells[i, 1].Value,
        //            Footer = range.Cells[i, 1].Value,
        //        };
        //    }
        //    wb.Close();
        //    app.Visible = false;

        //    return groups;
        //}


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData groupData)
        {
            List<GroupData> oldGroups = GroupData.GetGroupsFromDb();

            app.Groups
                   .CreateGroup(groupData);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

            List<GroupData> newGroup = GroupData.GetGroupsFromDb();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroups, newGroup);
            
            app.NavigationHelper.LogOut();
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupsList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetGroupsFromDb();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            Assert.AreEqual(fromUi.Count, fromDb.Count);

        }

        [Test]
        public void TestDBConnectivity2()
        {
            foreach(ContactData contact in GroupData.GetGroupsFromDb()[0].GetContactsFromDb())
            {
                Console.Out.WriteLine(contact);
            }

        }

        //[Test]
        //public void EmptyCreationTest()
        //{
        //    GroupData groupData = new GroupData("", "", "");

        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups
        //        .CreateGroup(groupData);

        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

        //    List<GroupData> newGroup = app.Groups.GetGroupsList();
        //    oldGroups.Add(groupData);
        //    oldGroups.Sort();
        //    newGroup.Sort();
        //    Assert.AreEqual(oldGroups, newGroup);

        //    app.NavigationHelper.LogOut();
        //}

        //[Test]
        //public void BadNameCreationTest()
        //{
        //    GroupData groupData = new GroupData("a'a", "", "");

        //    List<GroupData> oldGroups = app.Groups.GetGroupsList();

        //    app.Groups
        //        .CreateGroup(groupData);

        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

        //    List<GroupData> newGroup = app.Groups.GetGroupsList();
        //    oldGroups.Sort();
        //    newGroup.Sort();
        //    Assert.AreEqual(oldGroups, newGroup);

        //    app.NavigationHelper.LogOut();
        //}
    }
}
