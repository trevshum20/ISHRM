using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISHRM.Models;
using Microsoft.EntityFrameworkCore;

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
            var now = DateTime.Now;

            if ((now.Month == 8 && now.Day == 28 ) || (now.Month == 1 && now.Day == 10))
            {
                Alert a = new Alert();
                a.AlertName = "Pay Raises!";
                a.Completed = false;
                a.StartAlert = now;
                a.StudentEmploymentID = 1;

                repo.CreateAlert(a);
            }

            ViewBag.alerts = repo.GetAlerts();
            return View(); 
        }

        public IActionResult ClearAlert(int id)
        {
            Alert a = repo.GetAlerts().Where(x => x.AlertID == id).FirstOrDefault();
            repo.ResolveAlert(a);

            return RedirectToAction("Index");
        }

        public IActionResult EditEmployee(int id)
        {
            ViewBag.Supervisors = repo.Supervisors;
            ViewBag.SemesterYears = repo.SemesterYears;
            ViewBag.Positions = repo.Positions;
            ViewBag.Courses = repo.Course;
            ViewBag.Programs = repo.ProgramYears;
            Student_Employment s = repo.GetEmployees().Where(s => s.StudentEmploymentID == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public IActionResult EditEmployee(Student_Employment stu)
        {
            repo.EditStudentEmployee(stu);

            return RedirectToAction("EditEmployee", new { id = stu.StudentEmploymentID });
        }
        public IActionResult CreateEmployee()
        {
            

            ViewBag.Supervisors = repo.Supervisors;
            ViewBag.SemesterYears = repo.SemesterYears;
            ViewBag.Positions = repo.Positions;
            ViewBag.Courses = repo.Course;
            ViewBag.Programs = repo.ProgramYears;
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(Student_Employment stu)
        {
            

            repo.CreateStudentEmployee(stu);

            var weekToday = DateTime.Now.AddDays(7);
            var a = new Alert();
            a.AlertName = "Finish Authorization to work!";
            a.Completed = false;
            a.StartAlert = weekToday;
            a.StudentEmploymentID = stu.StudentEmploymentID;

            repo.CreateAlert(a);

            var a1 = new Alert();
            a1.AlertName = "Get eform from student";
            a1.Completed = false;
            a1.StartAlert = weekToday;
            a1.StudentEmploymentID = stu.StudentEmploymentID;

            repo.CreateAlert(a1);

            var a2 = new Alert();
            a2.AlertName = "Send Authorization to begin work email";
            a2.Completed = false;
            a2.StartAlert = weekToday;
            a2.StudentEmploymentID = stu.StudentEmploymentID;

            repo.CreateAlert(a2);




            return RedirectToAction("EmployeeData");
        }
        public IActionResult EmployeeData()
        {
            ViewBag.Employees = repo.GetEmployees();

            ViewBag.Supervisors = repo.Supervisors.ToList();

            ViewBag.Semesters = repo.SemesterYears.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult EmployeeData(int SupervisorID, int SemesterYearID)
        {

            ViewBag.Employees = repo.GetEmployees()
                .Where(s => s.SupervisorID == SupervisorID || SupervisorID == 0)
                .Where(s => s.SemesterYearID == SemesterYearID || SemesterYearID == 0);

            ViewBag.Supervisors = repo.Supervisors.ToList();

            ViewBag.Semesters = repo.SemesterYears.ToList();

            return View();
        }
        public IActionResult DeleteEmployee(int id)
        {
            Student_Employment s = repo.GetEmployees().Where(s => s.StudentEmploymentID == id).FirstOrDefault();
            repo.DeleteStudentEmployee(s);

            return RedirectToAction("EmployeeData");
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
