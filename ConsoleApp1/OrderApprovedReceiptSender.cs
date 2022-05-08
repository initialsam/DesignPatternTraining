// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

internal class OrderApprovedReceiptSender : INotificationService, IEventHandler<OrderApproved>
{
    private readonly IMessageService messageService;

    public OrderApprovedReceiptSender(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    void IEventHandler<OrderApproved>.Handle(OrderApproved e)
    {
        this.messageService.SendTermsAndConditions("", "");
    }

    void INotificationService.OrderApproved(Order order)
    {
        this.messageService.SendTermsAndConditions("", "");
    }
}