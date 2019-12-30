using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Exceptions;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() {
            var sellers = _sellerService.FindAll();
            return View(sellers);
        }

        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {
            return GetViewForSeller(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _sellerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            return GetViewForSeller(id);
        }

        private IActionResult GetViewForSeller(int? id) {
            if (id != null) {
                var seller = _sellerService.FindById(id.Value);
                if (seller != null) {
                    return View(seller);
                }
            }
            return NotFound();
        }

        public IActionResult Edit(int? id) {
            if (id != null) {
                var seller = _sellerService.FindById(id.Value);
                if (seller == null) {
                    return NotFound();
                }
                var departments = _departmentService.FindAll();
                var sellerForm = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(sellerForm);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (id != seller.Id) {
                return BadRequest();
            }
            try {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            } catch (NotFoundException) {
                return NotFound();
            } catch (DbConcurrencyException) {
                return BadRequest();
            }
        }
    }
}