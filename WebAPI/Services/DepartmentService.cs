using System.Collections.Generic;
using System.Linq;
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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList(); //Retorna a lista ordenada por nome
        }
        
        public void Insert(Department obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
