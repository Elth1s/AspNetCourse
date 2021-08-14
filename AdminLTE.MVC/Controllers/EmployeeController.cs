using AdminLTE.Models;
using AdminLTE.Models.ViewModels;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _db.Employees.Include(p => p.LocalCommunity);
            return View(employees);
        }

        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new EmployeeVM()
            {
                Employee = new Employee(),
                LocalCommunitySelectList = _db.LocalCommunities.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null)
            {
                return View(employeeVM);
            }
            else
            {
                employeeVM.Employee = _db.Employees.Find(id);
                if (employeeVM.Employee == null)
                {
                    return NotFound();
                }
                return View(employeeVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (employee.Id == 0)
                {
                    string upload = webRootPath + ENV.ImagePath;
                    string filename = Guid.NewGuid().ToString();
                    string extentions = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, filename + extentions), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    employee.Image = filename + extentions;

                    _db.Employees.Add(employee);
                }
                else
                {
                    var formObject = _db.Employees.AsNoTracking().FirstOrDefault(p => p.Id == employee.Id);
                    if (files.Count > 0)
                    {
                        string upload = webRootPath + ENV.ImagePath;
                        string filename = Guid.NewGuid().ToString();
                        string extentions = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, formObject.Image);
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, filename + extentions), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        employee.Image = filename + extentions;

                    }
                    else
                    {
                        employee.Image = formObject.Image;
                    }

                    _db.Employees.Update(employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Employee employee = _db.Employees.Include(p => p.LocalCommunity).FirstOrDefault(c => c.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Employee employee = _db.Employees.FirstOrDefault(c => c.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            string webRootPath = _webHostEnvironment.WebRootPath;
            var formObject = _db.Employees.AsNoTracking().FirstOrDefault(p => p.Id == employee.Id);
            string upload = webRootPath + ENV.ImagePath;
            var oldFile = Path.Combine(upload, formObject.Image);
            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
