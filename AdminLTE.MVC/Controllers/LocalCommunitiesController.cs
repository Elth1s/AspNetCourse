using AdminLTE.Models;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Controllers
{
    public class LocalCommunitiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LocalCommunitiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<LocalCommunity> localCommunityList = _db.LocalCommunities;
            return View(localCommunityList);
        }
    }
}
