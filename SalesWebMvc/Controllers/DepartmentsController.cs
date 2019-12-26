using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers {
    //A view precisa ter o menos nome que o controller (Departments), o sufixo Controller é um padrão do framework.
    public class DepartmentsController : Controller {
        public IActionResult Index() {
            var departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "Eletronics" });
            departments.Add(new Department { Id = 2, Name = "Tools" });
            return View(departments);
        }
    }
}