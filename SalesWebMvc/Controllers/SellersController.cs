using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index() {
            var sellers = await _sellerService.FindAllAsync();
            return View(sellers);
        }

        public async Task<IActionResult> Create() {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            if (!ModelState.IsValid) {
                var sellerForm = BuildSellerFormViewModel(seller);
                return View(sellerForm);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        private async Task<SellerFormViewModel> BuildSellerFormViewModel(Seller seller) {
            var departments = await _departmentService.FindAllAsync();
            var sellerForm = new SellerFormViewModel { Departments = departments, Seller = seller };
            return sellerForm;
        }

        public async Task<IActionResult> Delete(int? id) {
            return await GetViewForSeller(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            await _sellerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) {
            return await GetViewForSeller(id);
        }

        private async Task<IActionResult> GetViewForSeller(int? id) {
            if (id != null) {
                var seller = await _sellerService.FindByIdAsync(id.Value);
                if (seller != null) {
                    return View(seller);
                }
            }
            return RedirectToAction(nameof(Error), new { message = "Invalid id" });
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id != null) {
                var seller = await _sellerService.FindByIdAsync(id.Value);
                if (seller == null) {
                    return RedirectToAction(nameof(Error), new { message = "Invalid id" });
                }
                var departments = await _departmentService.FindAllAsync();
                var sellerForm = new SellerFormViewModel { Departments = departments, Seller = seller };
                return View(sellerForm);
            }
            return RedirectToAction(nameof(Error), new { message = "Invalid id" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller) {
            if (!ModelState.IsValid) {
                var sellerForm = BuildSellerFormViewModel(seller);
                return View(sellerForm);
            }
            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Invalid id" });
            }
            try {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            } catch (Exception e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}