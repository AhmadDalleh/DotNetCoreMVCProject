using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNetCoreMVCProject.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        private AppDbContext _context;
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            var products = from p in _context.Products select p;

            switch (sortOrder)
            {
                case "name-desc":
                    products = products.OrderByDescending(n => n.Name);
                    break;

                case "Date":
                    products = products.OrderBy(n => n.CreatedDate);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(n => n.CreatedDate);
                    break;
                case "Price":
                    products = products.OrderBy(n => n.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(n => n.Price);
                    break;
                default:
                    products = products.OrderBy(n => n.Name);
                    break;
            }

            var productsList = await products.ToListAsync();
            return View(productsList);
        }


        public IActionResult GetOneItem(int? id)
        {
            if (id != 0 || id != null)
            {
                Product pro = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                return PartialView("_ProductProfilePv", pro);
            }
            return NotFound();
        }


        public IActionResult AddItem()
        {
            Product product = new Product();
            return PartialView("_ProductsPV", product);
        }

        [HttpPost]
        public IActionResult AddItem(Product pro) 
        {

            if (ModelState.IsValid) 
            {
                _context.Products.Add(pro);
                _context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }                
            
            return View(pro);
        }

        public IActionResult EditItem(int id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            Product pro = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("_EditProductPv", pro);
        }
        [HttpPost]
        public IActionResult EditItem(Product pro)
        {

            _context.Products.Update(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult RemoveItem(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product pro = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("_RemoveProductPv", pro);
        }
        [HttpPost]
        public IActionResult RemoveItem(Product pro)
        {
            _context.Products.Remove(pro);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
