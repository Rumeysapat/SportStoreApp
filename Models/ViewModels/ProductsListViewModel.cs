using System;
using Chapter_7.Models.ViewModels;
using Chapter_7.Models;

namespace Chapter_7.Models
{
	public class ProductsListViewModel
	{
        public IEnumerable<Product>  Products { get; set; }
        public PagingInfo  PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}

