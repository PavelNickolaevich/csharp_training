

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETE_GROUP_WIN_TITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            OpenGroupsDialog();

            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for(int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#"+i, "");
                groups.Add(new GroupData()
                {
                    Name = item
                });

            }
            CloseGroupsDialog();
            aux.WinWait(WINTITLE);
            return groups;
        }

        public void AddGroup(GroupData group)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(group.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();

        }

        public void DeleteGroup (int index)
        {
            OpenGroupsDialog();
            SelectGroup(index);
            ClickDeleteGroupBtn();
            DeleteAllRadioButton();
            SubmitDeleteGroup();
        }

        private void SelectGroup(int index)
        {
            aux.ControlTreeView(
            GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
            "Select", "#0|#" + index, "");
        }

        private void SubmitDeleteGroup()
        {
            aux.ControlClick(DELETE_GROUP_WIN_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        private void DeleteAllRadioButton()
        {
            aux.ControlClick(DELETE_GROUP_WIN_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        private void ClickDeleteGroupBtn()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETE_GROUP_WIN_TITLE);
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public void CreateGroupIfNotExsist()
        {

            if (GetGroupList().Count == 1)
            {
                AddGroup(new GroupData()
                {
                    Name = "test"
                });
            }
        }
    }
}