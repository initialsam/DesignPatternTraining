﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMessageService messageService;
    private readonly IBillingSystem billingSystem;
    private readonly ILocationService locationService;
    private readonly IInventoryManagement inventoryManagement;
    public OrderService(
        IOrderRepository orderRepository,
        IMessageService messageService,
        IBillingSystem billingSystem,
        ILocationService locationService,
        IInventoryManagement inventoryManagement)
    {
        if (orderRepository == null)
            throw new ArgumentNullException("orderRepository");
        if (messageService == null)
            throw new ArgumentNullException("messageService");
        if (billingSystem == null)
            throw new ArgumentNullException("billingSystem");
        if (locationService == null)
            throw new ArgumentNullException("locationService");
        if (inventoryManagement == null)
            throw new ArgumentNullException("inventoryManagement");

        this.orderRepository = orderRepository;
        this.messageService = messageService;
        this.billingSystem = billingSystem;
        this.locationService = locationService;
        this.inventoryManagement = inventoryManagement;
    }

    public void ApproveOrder(Order order)
    {
        this.UpdateOrder(order);
        this.Notify(order);
    }

    private void UpdateOrder(Order order)
    {
        order.Approve();
        this.orderRepository.Save(order);
    }

    private void Notify(Order order)
    {
        this.messageService.SendTermsAndConditions("","");
        this.billingSystem.NotifyAccounting(order.Id,"");
        this.Fulfill(order);
    }

    private void Fulfill(Order order)
    {
        this.locationService.FindWarehouses();
        this.inventoryManagement.NotifyWarehouses(new List<Warehouse>());
    }
}
