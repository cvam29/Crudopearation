using crudop.Data;
using crudop.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
           _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategorylist = _db.Categories;

            return View(objCategorylist);
        }
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);   
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if(CategoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(CategoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        
       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoryFromDb = _db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(CategoryFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            
        }

    }

}
