﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter_7.Infrastructure;
using Chapter_7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_7.Pages
{
	
        public class CartModel : PageModel
        {
            private IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService)
        {

            Cart = cartService;
            repository = repo;

            }
            public Cart Cart { get; set; }
            public string ReturnUrl { get; set; }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }




        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }


        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Product.ProductId == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }




    }

    
}
