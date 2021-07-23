using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var list = await _departmentService.FindAllAsync();
            return View(list);
        }
        // GET: Departments/Create
         public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            return View(departments);
        }
        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            _departmentService.Insert(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
