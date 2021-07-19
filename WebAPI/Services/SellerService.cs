using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); //Include() dá o join na projeção
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id); //Retorna um obj com aquele Id passado por parametro
            _context.Seller.Remove(obj); //Remove o objeto do banco
            _context.SaveChanges(); //Confirma a operação de remover
        }

    }
}