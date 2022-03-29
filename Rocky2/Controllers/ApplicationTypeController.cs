using Microsoft.AspNetCore.Mvc;
using Rocky2.Data;
using Rocky2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky2.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> AppTypes = _db.ApplicationTypes;
            return View(AppTypes);
        }


        //Get - Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post - Create
        public async Task<IActionResult> Create(ApplicationType apptype)
        {
            await _db.ApplicationTypes.AddAsync(apptype);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
