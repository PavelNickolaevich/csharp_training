using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private DateInfo dateInfo;

        public class DateInfo
        {
            private string day;
            private string month;
            private string year;

            public DateInfo(string day, string month, string year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            public string Day { get => day; set => day = value; }
            public string Month { get => month; set => month = value; }
            public string Year { get => year; set => year = value; }
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, DateInfo dateInfo)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.dateInfo = new DateInfo(dateInfo.Day, dateInfo.Month, dateInfo.Year);
        }

        public string Firstname
        {
            get { return firstname; }
            set { this.firstname = value; }
        }

        public string Middlename
        {
            get => middlename;
            set { this.middlename = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { this.lastname = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { this.nickname = value; }
        }

        public DateInfo DateInfoProperty
        {
            get { return dateInfo; }
            set { this.dateInfo = value; }
        }
    }

}

