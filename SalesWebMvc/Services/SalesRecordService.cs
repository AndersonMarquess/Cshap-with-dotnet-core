using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services {
    public class SalesRecordService {

        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context) {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? initial, DateTime? final) {
            var result = from sr in _context.SalesRecord select sr;
            
            if (initial.HasValue) {
                result = result.Where(sr => sr.Date >= initial.Value);
            }
            if (final.HasValue) {
                result = result.Where(sr => sr.Date <= final.Value);
            }
            
            return await result
                .Include(sr => sr.Seller)
                .Include(sr => sr.Seller.Department)
                .OrderByDescending(sr => sr.Date)
                .ToListAsync();
        }
    }
}