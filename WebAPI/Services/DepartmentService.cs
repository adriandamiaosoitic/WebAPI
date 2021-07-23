using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class DepartmentService
    {

        private readonly WebAPIContext _context;

        public DepartmentService(WebAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {   
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); //Retorna a lista ordenada por nome
        }
        
        public void Insert(Department obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
