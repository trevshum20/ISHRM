using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISHRM.Models;

namespace ISHRM.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository repo;
        public HomeController(IStudentRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditEmployee()
        {
            ViewBag.Supervisors = repo.Supervisors;
            return View();
        }
        public IActionResult CreateEmployee()
        {
            ViewBag.Supervisors = repo.Supervisors;
            return View();
        }
        public IActionResult EmployeeData()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
