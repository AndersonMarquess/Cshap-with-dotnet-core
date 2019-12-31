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
            IQueryable<SalesRecord> result = GetQueryableFilterByDate(initial, final);

            return await result
                .Include(sr => sr.Seller)
                .Include(sr => sr.Seller.Department)
                .OrderByDescending(sr => sr.Date)
                .ToListAsync();
        }

        private IQueryable<SalesRecord> GetQueryableFilterByDate(DateTime? initial, DateTime? final) {
            var result = from sr in _context.SalesRecord select sr;

            if (initial.HasValue) {
                result = result.Where(sr => sr.Date >= initial.Value);
            }
            if (final.HasValue) {
                result = result.Where(sr => sr.Date <= final.Value);
            }

            return result;
        }

        public async Task<Dictionary<Department, List<SalesRecord>>> FindByDateGroupingAsync(DateTime? initial, DateTime? final) {
            var salesRecords = await FindByDateAsync(initial, final);
            var departments = _context.Department.ToList();
            var grouping = new Dictionary<Department, List<SalesRecord>>();

            departments.ForEach(d => {
                var sales = salesRecords.Where(sr => sr.Seller.Department == d).ToList();
                grouping.Add(d, sales);
            });

            return grouping;
        }
    }
}