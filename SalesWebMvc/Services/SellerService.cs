using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services {
    public class SellerService {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller) {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
            return _context.Seller.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Delete(int id) {
            var seller = FindById(id);            
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}