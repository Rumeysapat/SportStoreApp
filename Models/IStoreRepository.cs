using System;
namespace Chapter_7.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
      
    }
}

