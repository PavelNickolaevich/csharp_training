namespace mantis_tests
{
    public class ProjectCreateTests : AuthTestBase
    {

        [Test]
        public void CreateProjectTest()
        {
            string projectName = GenerateName(5);
            string description = GenerateName(5);

            ProjectData projectData = new ProjectData
            {
                ProjectName = projectName,
                ProjectStatus = ProjectData.WorkStatus.Release,
                IsInheritGlobalCategories = true,
                ProjectViewState = ProjectData.ViewStatus.Private,
                ProjectDescription = description
            };

            projectData.SetValuesFromEnums();

            app.MenuHelper
                .ClickManage();

            app.ManageHelper
                .ManageProject();

            int beforeProject = app.ManageHelper.GetAllProjectFromProjectTable().Count();
            List<ProjectData> oldProjects = app.ManageHelper.getAllProjects();
            oldProjects.Add(projectData);
            List<ProjectData> oldProjectSorted = oldProjects.OrderBy(p => p.ProjectName).ToList();

            app.ManageHelper
                .CreateProject()
                .FillProjectInfo(projectData)
                .SubmitAddProject();

            app.NotifyContentPage
                .ClickProceedBtn();

            int afterProject = app.ManageHelper.GetAllProjectFromProjectTable().Count();

            Assert.AreEqual(beforeProject + 1, afterProject);

            List<ProjectData> newProjects = app.ManageHelper.getAllProjects();
            List<ProjectData> newProjectSorted = newProjects.OrderBy(p => p.ProjectName).ToList();

            Assert.AreEqual(oldProjectSorted, newProjectSorted);
        }

    }
}

