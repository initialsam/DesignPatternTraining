using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Customer
    {
        public readonly Guid CustomerId;
        public readonly string MailAddress;

        public Customer(Guid customerId, string mailAddress)
        {
            if (mailAddress == null) throw new ArgumentNullException(nameof(mailAddress));

            this.CustomerId = customerId;
            this.MailAddress = mailAddress;
        }
    }
}
