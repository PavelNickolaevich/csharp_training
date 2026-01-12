using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectDeleteTests : AuthTestBase
    {
        [Test]
        public void DeleteProjectTest()
        {
            app.MenuHelper
                .ClickManage();

            app.ManageHelper
                .ManageProject();

            int beforeProject = app.ManageHelper.GetAllProjectFromProjectTable().Count();
            List<ProjectData> oldProjects = app.ManageHelper.getAllProjects();

            app.ManageHelper
                .SelectProjectByIndex(1)
                .DeleteProjectClick();

            app.NotifyContentPage
                .ClickSubmitDeleteBtn();

            int afterProject = app.ManageHelper.GetAllProjectFromProjectTable().Count();

            Assert.AreEqual(beforeProject, afterProject + 1);

            List<ProjectData> newProjects = app.ManageHelper.getAllProjects();
            oldProjects.RemoveAt(0);
            List<ProjectData> oldProjectSorted = oldProjects.OrderBy(p => p.ProjectName).ToList();
            List<ProjectData> newProjectSorted = oldProjects.OrderBy(p => p.ProjectName).ToList();

            Assert.AreEqual(oldProjectSorted, newProjectSorted);
        }
    }
}
