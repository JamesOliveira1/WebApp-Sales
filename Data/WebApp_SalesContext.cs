using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_Sales.Models;

namespace WebApp_Sales.Data
{
    public class WebApp_SalesContext : DbContext
    {
        public WebApp_SalesContext (DbContextOptions<WebApp_SalesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp_Sales.Models.Department> Department { get; set; }
    }
}
