using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {
        private By allCheckboxGroups = By.XPath("//input[@type='checkbox']");
        public GroupHelper(ApplicationManger manager) : base(manager) {
            
        }
        
        public GroupHelper CreateGroup(GroupData groupData)
        {
            manager.NavigationHelper.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            ReturnToGroupsPage();

            return this;
        }

 

        public GroupHelper Modify(int indexGroup, GroupData groupData)
        {
            manager.NavigationHelper.GoToGroupsPage();

            CreateGroupIfNotExsist();

            SelectGroup(indexGroup);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper ModifyByGroupId(string groupId, GroupData groupData)
        {
            manager.NavigationHelper.GoToGroupsPage();

            CreateGroupIfNotExsist();

            SelectGroup(groupId);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper RemoveGroupByIndex(int index)
        {

            manager.NavigationHelper.GoToGroupsPage();

            SelectGroup(index);
            DeleteGroup();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.NavigationHelper.GoToGroupsPage();

            SelectGroup(group.Id);
            DeleteGroup();
            ReturnToGroupsPage();

            return this;

        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupHash = null;
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("group_name")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            groupHash = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='"+id+"']")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupHash = null;
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private int GetGroupCount()
        {
            return driver.FindElements(allCheckboxGroups).Count;
        }

        public void CreateGroupIfNotExsist()
        {
            manager.NavigationHelper.GoToGroupsPage();

            if (GetGroupCount() == 0)
            {
                CreateGroup(new GroupData("test", "test", "test"));
            }
        }

        private List<GroupData> groupHash = null;


        public List<GroupData> GetGroupsList()
        {
            if (groupHash == null)
            {
                groupHash = new List<GroupData>();  
                manager.NavigationHelper.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupHash.Add(new GroupData(element.Text) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupHash);
        }

        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
