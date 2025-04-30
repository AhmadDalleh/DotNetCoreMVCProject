using DotNetCoreMVCProject.Data;
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
        
    }
}
