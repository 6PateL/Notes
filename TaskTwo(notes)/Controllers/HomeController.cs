using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using TaskTwo_notes_.Data;
using TaskTwo_notes_.Models;

namespace TaskTwo_notes_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<NoteModel> objectsModel = _db.Notes.ToList();
            return View(objectsModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NoteModel model)
        {
            if (ModelState.IsValid)
            {
                _db.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(); 
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); 
            }
            NoteModel? model = _db.Notes.Find(id);
            if(model == null)
            {
                return NotFound(); 
            }
            return View(model); 
        }
        [HttpPost]
        public IActionResult Edit(NoteModel model)
        {
            if (ModelState.IsValid)
            {
                _db.Update(model);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();  
            }
            return View(); 
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            NoteModel? model = _db.Notes.Find(id);
            if(model == null)
            {
                return NotFound(); 
            }
            _db.Notes.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
