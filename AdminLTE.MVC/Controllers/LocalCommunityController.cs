using AdminLTE.Models;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Controllers
{
    public class LocalCommunityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LocalCommunityController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<LocalCommunity> localCommunityList = _db.LocalCommunities;
            return View(localCommunityList);
        }
        public IActionResult Upsert(int? id)
        {
            LocalCommunity localCommunity = new LocalCommunity();

            if (id == null)
            {
                return View(localCommunity);
            }
            else
            {
                localCommunity = _db.LocalCommunities.Find(id);
                if (localCommunity == null)
                {
                    return NotFound();
                }
                return View(localCommunity);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(LocalCommunity localCommunity)
        {
            if (ModelState.IsValid)
            {
                if (localCommunity.Id == 0)
                {
                    _db.LocalCommunities.Add(localCommunity);
                }
                else
                {
                    var formObject = _db.LocalCommunities.AsNoTracking().FirstOrDefault(p => p.Id == localCommunity.Id);
                    _db.LocalCommunities.Update(localCommunity);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localCommunity);
        }
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            LocalCommunity localCommunity = _db.LocalCommunities.FirstOrDefault(c => c.Id == id);
            if (localCommunity == null)
            {
                return NotFound();
            }

            return View(localCommunity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            LocalCommunity localCommunity = _db.LocalCommunities.FirstOrDefault(c => c.Id == id);
            if (localCommunity == null)
            {
                return NotFound();
            }
            _db.LocalCommunities.Remove(localCommunity);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
