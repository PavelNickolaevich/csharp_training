using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    internal class GroupData
    {
        private string name;
        private string header;
        private string footer;
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;   
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Header
        {
            get { return header; }
            set {  header = value; }
        }
        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }


    }
}
