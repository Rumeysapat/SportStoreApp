using System;
using System.Linq;





namespace Chapter_7.Models
{
	public interface IOrderRepository
	{
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}

