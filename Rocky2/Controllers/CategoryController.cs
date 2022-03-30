using Microsoft.AspNetCore.Mvc;
using Rocky2.Data;
using Rocky2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categories;
            return View(objList);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post - Create
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
            
        }

        //Get - Edit 
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0 )
                return NotFound();

            var currentCategory = _db.Categories
                                      .Where(ctgr => ctgr.Id == id)
                                      .SingleOrDefault();
            if (currentCategory is null)
                return NotFound();

            return View(currentCategory);
        }


        //Post - Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            var currentCategory = _db.Categories
                                    .Where(cat => cat.Id == category.Id)
                                    .SingleOrDefault();
            if (currentCategory is not null)
            {
                currentCategory.CategoryName = category.CategoryName;
                currentCategory.DisplayOrder = category.DisplayOrder;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        //Get - Delete  
        public async Task<IActionResult> Delete(int? id)
        {
            
            var currentCategory = _db.Categories
                                      .Where(ctgr => ctgr.Id == id)
                                      .SingleOrDefault();
            _db.Categories.Remove(currentCategory);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
