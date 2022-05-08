using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly CommerceContext context;

        public SqlOrderRepository(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            this.context = context;
        }

        public Order GetById(Guid id)
        {
            return this.context.Orders.Find(id)
                ?? throw new KeyNotFoundException($"No Order with ID '{id}' was found.");
        }

        public void Save(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            if (this.context.IsNew(order))
            {
                this.context.Orders.Add(order);
            }
        }
    }
}
