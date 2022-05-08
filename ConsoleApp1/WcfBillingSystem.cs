using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WcfBillingSystem : IBillingSystem
    {
        public void NotifyAccounting(Guid orderId, string notification)
        {
            // Calls the web service of the external billing system.
            Debug.WriteLine($"Accounting notified for order id {orderId} and notification '{notification}.");
        }
    }
}
