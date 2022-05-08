// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

internal class AccountingNotifier : INotificationService, IEventHandler<OrderApproved>
{
    private readonly IBillingSystem billingSystem;

    public AccountingNotifier(IBillingSystem billingSystem)
    {
        this.billingSystem = billingSystem;
    }

    public void Handle(OrderApproved e)
    {
        billingSystem.NotifyAccounting(e.OrderId, "");
    }

    public void OrderApproved(Order order)
    {
        billingSystem.NotifyAccounting(order.Id, "");
    }
}