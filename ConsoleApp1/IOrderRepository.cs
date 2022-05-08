namespace ConsoleApp1
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        void Save(Order order);
    }
}