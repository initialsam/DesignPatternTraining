namespace ConsoleApp1
{
    public interface IBillingSystem
    {
        void NotifyAccounting(Guid orderId, string notification);
    }
}