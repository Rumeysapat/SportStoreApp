using System;
using Chapter_7.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;



namespace Chapter_7.ComponentsFolder
{
	public class CartSummaryViewComponent:ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

