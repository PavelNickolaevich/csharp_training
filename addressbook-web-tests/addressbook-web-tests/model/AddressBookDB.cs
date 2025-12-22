using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LinqToDB;
using LinqToDB.Data;


namespace WebAddressBookTests.model
{
    public class AddressBookDB : DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups
        {
            get { return this.GetTable<GroupData>(); }
        }

        public ITable<ContactData> Contacts
        {
            get { return this.GetTable<ContactData>(); }
        }

        public ITable<GroupContactRelation> Gcr
        {
           get { return this.GetTable<GroupContactRelation>();  }
        }
    }
}
