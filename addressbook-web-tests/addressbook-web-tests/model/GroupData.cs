using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressBookTests.model;

namespace WebAddressBookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData()
        {

        }

        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;   
        }
      
        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null)) {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheaders= " + Header + "\nfooter=" + Footer; 
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();

            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        //from gcr in db.Gcr.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        from gcr in db.Gcr.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == null)
                        select c).Distinct().ToList();

            }
        }

    } 
}
