using System;
using Microsoft.EntityFrameworkCore;

namespace Chapter_7.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreSportDbContext context;


        public EFOrderRepository(StoreSportDbContext ctx)
        {
            context = ctx;
        }


        public IQueryable<Order> Orders => context.Orders
                           .Include(o => o.Lines)
                           .ThenInclude(l => l.Product);


        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }

}