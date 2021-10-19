using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Sales.Data;
using WebApp_Sales.Models;

namespace WebApp_Sales.Services
{
    public class DepartmentService
    {
        private readonly WebApp_SalesContext _context;

        public DepartmentService(WebApp_SalesContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
