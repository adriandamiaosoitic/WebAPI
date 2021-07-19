using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.ViewModels;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public  IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //GET
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost] //Cadastro de informações por meio do metodo POST
        [ValidateAntiForgeryToken] //Previne a página de ataques CSRF
        public IActionResult Create(Seller seller) //Sera instanciado normalmente
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}