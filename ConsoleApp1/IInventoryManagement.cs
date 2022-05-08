namespace ConsoleApp1
{
    public interface IInventoryManagement
    {
        void NotifyWarehouses(IEnumerable<Warehouse> warehouses);
    }
}