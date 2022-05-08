using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

public class OrderServiceV2 : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly INotificationService notificationService;

    public OrderServiceV2(
        IOrderRepository orderRepository,
        INotificationService notificationService)
    {
        this.orderRepository = orderRepository;
        this.notificationService = notificationService;
    }

    public void ApproveOrder(Order order)
    {
        this.UpdateOrder(order);

        this.notificationService.OrderApproved(order);
    }

    private void UpdateOrder(Order order)
    {
        order.Approve();
        this.orderRepository.Save(order);
    }
}
