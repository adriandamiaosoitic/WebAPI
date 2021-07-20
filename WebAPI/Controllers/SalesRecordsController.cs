using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly WebAPIContext _context;

        public SalesRecordsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesRecord.ToListAsync());
        }

        public async Task<IActionResult> SimpleSearch()
        {
            return View();
        }
        public async Task<IActionResult> GroupingSearch()
        {
            return View();
        }
    }
}
