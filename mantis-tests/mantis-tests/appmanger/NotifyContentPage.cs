using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class NotifyContentPage : HelperBase
    {
        private string submitDeleteBtn = "//form/input[@type='submit']";
        private string proceedBtn = "//div[@class='btn-group']";

        public NotifyContentPage(ApplicationManger manger) : base(manger)
        {
        }

        public void ClickSubmitDeleteBtn()
        {
            driver.FindElement(By.XPath(submitDeleteBtn)).Click();
        }

        public void ClickProceedBtn()
        {
            driver.FindElement(By.XPath(proceedBtn)).Click();
        }
    }
}
