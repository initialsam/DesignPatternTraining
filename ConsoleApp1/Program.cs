// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var orderRepository = new SqlOrderRepository(new CommerceContext(""));

var notificationService = new CompositeNotificationService(
    new INotificationService[]
    {
        new OrderApprovedReceiptSender(new SmtpMailMessageService()),
        new AccountingNotifier(new WcfBillingSystem()),
        new OrderFulfillment(new WcfLocationService(), new WcfInventoryManagement())
    });

var orderServiveV2 = new OrderServiceV2(orderRepository, notificationService);

var orderApprovedHandler = new CompositeEventHandler<OrderApproved>(
    new IEventHandler<OrderApproved>[]
    {
        new OrderApprovedReceiptSender(new SmtpMailMessageService()),
        new AccountingNotifier(new WcfBillingSystem()),
        new OrderFulfillment(new WcfLocationService(), new WcfInventoryManagement())
    });

var orderServiceV3 = new OrderServiceV3(orderRepository, orderApprovedHandler);

//Facade

//Composite