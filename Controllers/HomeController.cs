using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chapter_7.Models;
using Chapter_7.Models.ViewModels;

namespace Chapter_7.Controllers;

public class HomeController : Controller
{
    private IStoreRepository repository;

    private readonly ILogger<HomeController> _logger;

    public int PageSize = 4;

    public HomeController(ILogger<HomeController> logger, IStoreRepository repo)
    {
        _logger = logger;
        repository = repo;
    }


    public ViewResult Index(string category,int productPage = 1)
           => View(new ProductsListViewModel
           {
               Products = repository.Products
                 .Where(p => category == null || p.Category == category)
                   .OrderBy(p => p.ProductId)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = productPage,
                   ItemsPerPage = PageSize,
                   TotalItems = category == null ?
                   repository.Products.Count():
                   repository.Products.Where(e =>
                    e.Category == category).Count()






               }
           });





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

