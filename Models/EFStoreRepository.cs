using System;
using System.Linq;


namespace Chapter_7.Models
{
    public class EFStoreRepository: IStoreRepository
    {

        private StoreSportDbContext context;



        public EFStoreRepository(StoreSportDbContext ctx)
        {

            context = ctx;


        }


        public IQueryable<Product> Products => context.Products;

       
    }
}

