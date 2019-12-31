using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers {
    public class SalesRecordsController : Controller {

        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService) {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? initial, DateTime? final) {
            if (initial.HasValue) {
                ViewData["initial"] = initial.Value.ToString("yyyy-MM-dd");
            }
            if (final.HasValue) {
                ViewData["final"] = final.Value.ToString("yyyy-MM-dd");
            }
            var sales = await _salesRecordService.FindByDateAsync(initial, final);
            return View(sales);
        }
    }
}