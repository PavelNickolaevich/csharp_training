using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressBookTests 
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private DateInfo dateInfo;
        private string allEmail;
        private string allPhones;

        public class DateInfo
        {
            private string day;
            private string month;
            private string year;

            public DateInfo()
            {

            }

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

    

        public ContactData()
        {

        }

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public ContactData(
            string firstname,
            string lastname,
            string addresses,
            string homePhone,
            string mobileHome,
            string workHome,
            string email,
            string email2,
            string email3
            )
        {
            this.firstname = firstname;
            this.lastname = lastname;
            Address = addresses;
            HomePhone = homePhone;
            MobilePhone = mobileHome;
            WorkPhone = workHome;
            Email = email;
            Email2 = email2;
            Email3 = email3;
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
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; } 
        public string Email { get; set; } 
        public string Email2 { get; set; } 
        public string Email3 { get; set; } 

        public DateInfo DateInfoProperty
        {
            get { return dateInfo; }
            set { this.dateInfo = value; }
        }


        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).TrimEnd('\r', '\n');
                }
            }
            set
            {
                allEmail = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email + "\r\n";
            }

        }

        public string AllPhones
        {
            get { if (allPhones != null)
                {
                    return allPhones;
                } 
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone).Trim()).TrimEnd('\r', '\n');
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone
                    .Replace("H:", "")
                    .Replace("M:", "")
                    .Replace("W:", "")
                    .Replace(" ", "")
                    .Replace("-", "")
                    .Replace("(", "")
                    .Replace(")", "") + "\r\n";
            }
   
        }

        public string Id { get; set; }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return $"firstname: {Firstname}, lastname: {Lastname}";
        }

        public bool Equals(ContactData other)
        {
            {
                if (Object.ReferenceEquals(other, null))
                {
                    return false;
                }
                if (Object.ReferenceEquals(this, other))
                {
                    return true;
                }
                return Firstname == other.Firstname 
                    && Lastname == other.Lastname;
            }
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            // Сравниваем по Firstname
            int firstNameComparison = Firstname.CompareTo(other.Firstname);
            if (firstNameComparison != 0)
            {
                return firstNameComparison;
            }

            // Если Firstname равны, сравниваем по Middlename
            return Lastname.CompareTo(other.Lastname);
        }
    }
}

