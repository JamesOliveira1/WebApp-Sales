using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Sales.Data;
using WebApp_Sales.Models;
using Microsoft.EntityFrameworkCore;
using WebApp_Sales.Services.Exceptions;

namespace WebApp_Sales.Services
{
    public class SellerService
    {
        private readonly WebApp_SalesContext _context;

        public SellerService(WebApp_SalesContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyExcpetion e)
            {
                throw new DbConcurrencyExcpetion(e.Message);
            }
        }

    }
}
