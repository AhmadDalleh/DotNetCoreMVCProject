using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMVCProject.Controllers
{
    public class ClassController : Controller
    {
        public ClassController(AppDbContext context, IConfiguration conf)
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
    }
}
