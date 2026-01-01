using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        private GroupHelper groupHelper;
        public static string WINTITLE = "Free Address Book";
 
        public ApplicationManager() {

            Application app = Application.Launch(@"C:\Users\natit\Downloads\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);
   
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public Window MainWindow
        {
            get; private set;
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

    }
}
