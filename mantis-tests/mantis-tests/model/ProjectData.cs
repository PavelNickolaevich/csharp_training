using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>
{

        public ProjectData()
        {

        }

        public ProjectData(string name, string status, string viewStatus, string description)
        {
            ProjectName = name;
            ProjectStatusValue = status;
            ProjectViewStateValue = viewStatus;
            ProjectDescription = description;
        }

        public ProjectData(string name, WorkStatus status, bool isInheritGlobalCategories, ViewStatus viewStatus, string description)
        {
            ProjectName = name;
            ProjectStatus = status;
            IsInheritGlobalCategories = isInheritGlobalCategories;
            ProjectViewState = viewStatus;
            ProjectDescription = description;
        }

        public string ProjectName { get; set; }  
        public WorkStatus ProjectStatus { get; set; }
        public bool IsInheritGlobalCategories { get; set; }
        public ViewStatus ProjectViewState { get; set; }
        public string ProjectDescription { get; set; }

        public string ProjectStatusValue { get; set; }
        public string ProjectViewStateValue { get; set; }

        public enum WorkStatus
        {
            Development = 10,
            Release = 30,
            Stable = 50,
            Obsolete = 70
        }

        public enum ViewStatus
        {
            Public = 10,
            Private = 50
        }

        public void SetValuesFromEnums()
        {
            ProjectStatusValue = ProjectStatus switch
            {
                WorkStatus.Development => "в разработке",
                WorkStatus.Release => "выпущен",
                WorkStatus.Stable => "стабильный",
                WorkStatus.Obsolete => "устаревший",
                _ => ProjectStatus.ToString()
            };

            ProjectViewStateValue = ProjectViewState switch
            {
                ViewStatus.Public => "публичный",
                ViewStatus.Private => "приватный",
                _ => ProjectViewState.ToString()
            };
        }

        public override string ToString()
        {
            return $"Project Name: {ProjectName}\n" +
                   $"Status: {ProjectStatusValue}\n" +
                   $"View Status: {ProjectViewStateValue}\n" +
                   $"Inherit Global Categories: {IsInheritGlobalCategories}\n" +
                   $"Description: {ProjectDescription}";
        }

        public bool Equals(ProjectData other)
        {
            {
                if (Object.ReferenceEquals(other, null))
                {
                    return false;
                }
                if (Object.ReferenceEquals(this, other))
                {
                    return true;
                }
                return ProjectName == other.ProjectName
                    && ProjectStatusValue == other.ProjectStatusValue
                    && ProjectViewStateValue == other.ProjectViewStateValue
                    && ProjectDescription == other.ProjectDescription;  
            }
        }
    }
}
