﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.ViewModels;
using WebAPI.Services;
using WebAPI.Services.Exceptions;

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
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided!" }); //Retorna uma resposta básica
            }

            var obj = _sellerService.FindById(id.Value); //.Value é porque ele é Nullable/Opcional
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
     
            _sellerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        //GET Details
        public IActionResult Details(int? id)
        {
            if(id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided!" });
            }
            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found!" });
            }
            return View(obj);
        }

        //Edit GET -> Tem a função de retornar para a view os dados nos campos 
        public IActionResult Edit(int? id) //O ID é obrigatório mas coloca-se o operador de opcional para evitar um possível erro de execução
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Provided!" });
            }

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found!" });
            }

            List<Department> departments = _departmentService.FindAll(); //Lista para povoar o select da tela de edição
            SellerFormViewModel viewModel = new SellerFormViewModel
            { 
                Seller = obj, // Dados do proprio objeto a ser editado
                Departments = departments
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            
            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Mismatch!" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }catch(ApplicationException e) 
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }

        public IActionResult Error(string message) //Essa ação serve para retornar a view de Erro
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //Se o primeiro é nulo, pega o segundo
            };

            return View(viewModel);
        }
    }
}