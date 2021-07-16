using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class SellerService
    {
        private WebAPIContext _context;
            
        public SellerService(WebAPIContext context) //Injeção de dependência
        {
            _context = context;
        }
    }
}
