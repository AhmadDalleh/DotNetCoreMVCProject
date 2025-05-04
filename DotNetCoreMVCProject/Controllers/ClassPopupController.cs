using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVCProject.Controllers
{
    public class ClassPopupController : Controller
    {
        public ClassPopupController(AppDbContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        private readonly AppDbContext _context;
        private readonly IConfiguration _conf;

        public IActionResult Index()
        {
            List<TheClass> classes = _context.Classes.ToList();
            return View(classes);
        }
        public IActionResult AddClass()
        {
            TheClass theClass = new TheClass();
            theClass.Students.Add(new TheClassStudent());
            return PartialView("_AddClassPV",theClass);
        }

        [HttpPost]
        public IActionResult AddClass(TheClass theClass)
        {
            _context.Classes.Add(theClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
