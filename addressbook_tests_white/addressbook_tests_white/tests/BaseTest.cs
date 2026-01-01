using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Configuration;

namespace addressbook_tests_white
{
    public class BaseTest
    {
        public ApplicationManager app;

        [SetUp]
        public void InitApp()
        {
            app = new ApplicationManager();
            CoreAppXmlConfiguration.Instance.BusyTimeout = 5000;
            CoreAppXmlConfiguration.Instance.FindWindowTimeout = 10000;
            
        }

        [TearDown]
        public void StopApp()
        {
            app.Stop();
        }


    }
}
