using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return $"GroupData(Name: {Name})";
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }
}
