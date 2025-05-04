using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Pkcs;

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

        public IActionResult AddClass()
        {
            TheClass _class = new TheClass();
            _class.Students.Add(new TheClassStudent());
            return View("AddClass", _class);
        }

        [HttpPost]
        public IActionResult AddClass(TheClass theClass)
        {
            _context.Classes.Add(theClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            return View(theClass);
        }

        public IActionResult Edit(int id)
        {
            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            return View(theClass);
        }

        [HttpPost]
        public IActionResult Edit(TheClass theClass)
        {
            List<TheClassStudent> students = _context.Students.Where(x=>x.TheClassId == theClass.Id).ToList();
            _context.Students.RemoveRange(students);
            _context.SaveChanges();

            _context.Classes.Update(theClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            return View(theClass);
        }

        [HttpPost]
        public IActionResult Delete(TheClass theClass) 
        {
            _context.Attach(theClass);
            _context.Entry(theClass).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
