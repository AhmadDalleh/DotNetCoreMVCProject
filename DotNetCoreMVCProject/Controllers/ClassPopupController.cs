using DotNetCoreMVCProject.Data;
using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return PartialView("_AddClassPV", theClass);
        }

        [HttpPost]
        public IActionResult AddClass([FromBody] TheClass theClass)
        {
            if (theClass.Students != null)
                theClass.Students = theClass.Students.Where(s => s.Name != null).ToList();
            _context.Classes.Add(theClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            return PartialView("_DetailsClassPV", theClass);
        }

        //Get
        public IActionResult Edit(int id)
        {
            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            theClass.Students.Add(new TheClassStudent());
            return PartialView("_EditClassPV", theClass);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(TheClass theClass)
        {
            List<TheClassStudent> students = _context.Students.Where(x => x.TheClassId == theClass.Id).ToList();
            _context.Students.RemoveRange(students);
            _context.SaveChanges();

            if (theClass.Students != null)
                theClass.Students = theClass.Students.Where(s => s.Name != null).ToList();
            _context.Classes.Update(theClass);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {

            var theClass = _context.Classes.Where(x => x.Id == id).Include(s => s.Students).FirstOrDefault();
            return PartialView("_DeleteClassPV", theClass);
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


