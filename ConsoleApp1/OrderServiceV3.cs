using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

public class OrderServiceV3 : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IEventHandler<OrderApproved> handler;

    public OrderServiceV3(
        IOrderRepository orderRepository,
        IEventHandler<OrderApproved> handler)
    {
        this.orderRepository = orderRepository;
        this.handler = handler;
    }

    public void ApproveOrder(Order order)
    {
        this.UpdateOrder(order);

        this.handler.Handle(new OrderApproved(order.Id));
    }

    private void UpdateOrder(Order order)
    {
        order.Approve();
        this.orderRepository.Save(order);
    }
}
