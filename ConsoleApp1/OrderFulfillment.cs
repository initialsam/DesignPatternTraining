using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderFulfillment : IOrderFulfillment, INotificationService,IEventHandler<OrderApproved>
    {
        private readonly ILocationService locationService;
        private readonly IInventoryManagement inventoryManagement;

        public OrderFulfillment(
            ILocationService locationService,
            IInventoryManagement inventoryManagement)
        {
            this.locationService = locationService;
            this.inventoryManagement = inventoryManagement;
        }

        public void Fulfill(Order order)
        {
            this.locationService.FindWarehouses();
            this.inventoryManagement.NotifyWarehouses(new List<Warehouse>());
        }

        public void Handle(OrderApproved e)
        {
            this.locationService.FindWarehouses();
            this.inventoryManagement.NotifyWarehouses(new List<Warehouse>());
        }

        public void OrderApproved(Order order)
        {
            this.locationService.FindWarehouses();
            this.inventoryManagement.NotifyWarehouses(new List<Warehouse>());
        }
    }
}
