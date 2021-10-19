using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Sales.Services.Exceptions
{
    public class DbConcurrencyExcpetion : ApplicationException
    {
        public DbConcurrencyExcpetion(string message) : base(message)
        {

        }
    }
}
