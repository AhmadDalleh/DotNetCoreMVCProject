using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVCProject.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        private AppDbContext _context;
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult AddItem()
        {
            Product product = new Product();
            return PartialView("_ProductsPV", product);
        }

        [HttpPost]
        public IActionResult AddItem(Product pro) 
        {
            _context.Products.Add(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
