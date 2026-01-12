using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class MenuHelper : HelperBase
{
        string manage = "//i[@class='menu-icon fa fa-gears']";
        public MenuHelper(ApplicationManger manger) : base(manger) { }

        public MenuHelper ClickManage()
        {
            driver.FindElement(By.XPath(manage)).Click();

            return this;

        }

    }
}
