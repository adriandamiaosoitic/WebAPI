using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {

            List<Department> list = new List<Department>();

            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Computers" });
            list.Add(new Department { Id = 3, Name = "Smart Home" });
            list.Add(new Department { Id = 4, Name = "Home and Kitchen" });
            list.Add(new Department { Id = 5, Name = "Tools" });
            list.Add(new Department { Id = 6, Name = "Video Games" });

            return View(list);
        }
    }
}
