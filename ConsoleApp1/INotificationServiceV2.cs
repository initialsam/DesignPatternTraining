using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface INotificationServiceV2
    {
        void OrderApproved(Order order);
        void OrderCancelled(Order order);
        void OrderShipped(Order order);
        void OrderDelivered(Order order);
        void CustomerCreated(Customer customer);
        void CustomerMadePreferred(Customer customer);
    }
}
