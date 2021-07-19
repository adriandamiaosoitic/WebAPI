using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Exceptions;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class SellerService
    {
        private readonly WebAPIContext _context;

        public SellerService(WebAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return  _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj); //Adiciona o objeto no banco de dados
            await _context.SaveChangesAsync(); //Confirma a alteração no banco
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id); //Include() dá o join na projeção
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id); //Retorna um obj com aquele Id passado por parametro
            _context.Seller.Remove(obj); //Remove o objeto do banco
            await _context.SaveChangesAsync(); //Confirma a operação de remover
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException e) //Interceptação de uma exceção em nivel de acesso de dados e lançamento para a camada de serviço, garantindo que a camada de controle não tenha que lidar com exceções de acesso a dados(repositories)
            {
                throw new DbConcurrencyException(e.Message);
            }
            

        }

    }
}