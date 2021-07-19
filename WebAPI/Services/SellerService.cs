using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Services
{
    public class SellerService
    {
        private readonly WebAPIContext _context;

        public SellerService(WebAPIContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return  _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj); //Adiciona o objeto no banco de dados
            _context.SaveChanges(); //Confirma a alteração no banco
        }

    }
}