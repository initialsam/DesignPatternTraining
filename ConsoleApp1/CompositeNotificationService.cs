using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CompositeNotificationService: INotificationService
    {
        IEnumerable<INotificationService> services;

        public CompositeNotificationService(IEnumerable<INotificationService> services)
        {
            this.services = services;
        }

        public void OrderApproved(Order order)
        {
            foreach (var service in this.services)
            {
                service.OrderApproved(order);
            }
        }
    }
}
