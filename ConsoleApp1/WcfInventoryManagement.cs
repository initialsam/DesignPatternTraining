using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WcfInventoryManagement : IInventoryManagement
    {
        public void NotifyWarehouses(IEnumerable<Warehouse> warehouses)
        {
            // Notifies the warehouses about the new order
            Debug.WriteLine("Wharehouses notified.");
        }
    }
}
