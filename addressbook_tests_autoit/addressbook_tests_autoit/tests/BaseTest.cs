using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class BaseTest
    {
        public ApplicationManager app;

        [SetUp]
        public void InitApp()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void StopApp()
        {
            app.Stop();
        }
    }
}
