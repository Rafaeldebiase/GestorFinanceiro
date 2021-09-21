using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Email email &&
                   Address == email.Address;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address);
        }
    }
}
