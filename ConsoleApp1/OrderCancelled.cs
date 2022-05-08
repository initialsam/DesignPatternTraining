namespace ConsoleApp1
{
    public class OrderCancelled
    {
        public readonly Guid OrderId;

        public OrderCancelled(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
