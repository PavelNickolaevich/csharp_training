using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManageHelper : HelperBase
    {
        private string manageProjectBtn = "//a[contains(@href, 'manage_proj_page')]";
        private string createProjectBtn = "//button[@class='btn btn-primary btn-white btn-round']";
        private string addProjectBtn = "//input[@class='btn btn-primary btn-white btn-round']";
        private string projectTable = "(//div[@class='table-responsive']/table/tbody)[1]";
        private string projectRowsTable = "(//div[@class='table-responsive']/table/tbody)[1]/tr";
        private string deleteBtn = "project-delete-form";

        public List<ProjectData>? hashProject = null;
        public ManageHelper(ApplicationManger manger) : base(manger)
        {
        }

        public ManageHelper ManageProject()
        {
            driver.FindElement(By.XPath(manageProjectBtn)).Click();
            return this;
        }

        public ManageHelper CreateProject()
        {
            driver.FindElement(By.XPath(createProjectBtn)).Click();
            hashProject = null;
            return this;
        }

        public ManageHelper DeleteProjectClick()
        {
            driver.FindElement(By.Id(deleteBtn)).Click();
            return this;
        }

        public List<IWebElement> GetAllProjectFromProjectTable()
        {
            return driver.FindElements(By.XPath(projectRowsTable)).ToList();
        }

        public List<ProjectData> getAllProjects()
        {
            if (hashProject == null)
            {
                hashProject = new List<ProjectData>();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath(projectRowsTable));

                foreach (IWebElement element in elements)
                {
                    string name = element.FindElements(By.TagName("td"))[0].Text;
                    string status = element.FindElements(By.TagName("td"))[1].Text;
                    string viewStatus = element.FindElements(By.TagName("td"))[3].Text;
                    string description = element.FindElements(By.TagName("td"))[4].Text;
                    hashProject.Add(new ProjectData(name, status, viewStatus, description));
                    //{
                    //    Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    //});
                }
            }
            return [.. hashProject];
        }

        public ManageHelper SelectProjectByIndex(int index)
        {
            driver.FindElement(By.XPath(projectRowsTable + "[" + index + "]/td[1]/a")).Click();
            return this;

        }


        public ManageHelper SubmitAddProject()
        {
            driver.FindElement(By.XPath(addProjectBtn)).Click();
            return this;
        }

        public ManageHelper FillProjectInfo(ProjectData projectData)
        {
            Type(By.Id("project-name"), projectData.ProjectName);
            SelectProjectStatus(projectData.ProjectStatus);
            if (!projectData.IsInheritGlobalCategories)
            {
                driver.FindElement(By.XPath("//input[@id='project-inherit-global']/..")).Click();
            }
            SelectProjectViewState(projectData.ProjectViewState);
            Type(By.Id("project-description"), projectData.ProjectDescription);
            return this;
            
        }

        private void SelectProjectViewState(ProjectData.ViewStatus projectViewState)
        {
            var select = new SelectElement(driver.FindElement(By.Id("project-view-state")));
            select.SelectByValue(((int)projectViewState).ToString());
        }

        private void SelectProjectStatus(ProjectData.WorkStatus projectStatus)
        {
            var select = new SelectElement(driver.FindElement(By.Id("project-status")));
            select.SelectByValue(((int)projectStatus).ToString());
        }

    }
}
