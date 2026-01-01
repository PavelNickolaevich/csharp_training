using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;


namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {

        public static string DELETE_GROUP_WIN_TITLE = "Delete group";
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) {}

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode node = tree.Nodes[0];

            foreach (TreeNode item in node.Nodes)
            {
                groups.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialog(dialog);
            return groups;
        }

        public void AddGroup(GroupData group)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(group.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);

        }

        public void DeleteGroup(int index)
        {
                Window dialog = SelectGroup(index);
                Window deleteDialog = ClickDeleteGroupBtn(dialog);
                DeleteAllRadioButton(deleteDialog);
                SubmitDeleteGroup(deleteDialog);
                CloseGroupsDialog(dialog);
        }

        private Window SelectGroup(int index)
        {
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode rootNode = tree.Nodes[0];
            TreeNode groupNode = rootNode.Nodes[index];
            groupNode.Select();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        private void SubmitDeleteGroup(Window dialog)
        {
            dialog.Get<Button>("uxOKAddressButton").Click();
        }

        private void DeleteAllRadioButton(Window dialog)
        {
            dialog.Get<RadioButton>("uxDeleteAllRadioButton").Click();
        }

        private Window ClickDeleteGroupBtn(Window dialog)
        {
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE).ModalWindow(DELETE_GROUP_WIN_TITLE);
        }

        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();  
        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
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
