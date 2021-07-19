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

        //GET delete -> Retorna para a view o objeto a ser deletado
        public IActionResult Delete(int? id)  //? id opcional
        { 
            if(id == null)
            {
                return NotFound(); //Retorna uma resposta básica
            }

            var obj = _sellerService.FindById(id.Value); //.Value é porque ele é Nullable/Opcional
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            _sellerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        //GET Details
        public IActionResult Details(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}