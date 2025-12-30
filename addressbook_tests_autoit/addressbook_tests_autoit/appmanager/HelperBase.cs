using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;
        public HelperBase(ApplicationManager manager)
        {
            this.aux = manager.Aux;
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}