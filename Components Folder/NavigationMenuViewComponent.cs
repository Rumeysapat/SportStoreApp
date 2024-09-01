using System;
using System.Linq;
using Chapter_7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter_7.ComponentsFolder
{
	public class NavigationMenuViewComponent:ViewComponent
	{
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products

                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }

}


