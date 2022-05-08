using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderApproved
    {
        public readonly Guid OrderId;

        public OrderApproved(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
