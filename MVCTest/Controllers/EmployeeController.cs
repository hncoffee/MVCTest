using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.ViewModels;


namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "Hello World is old now, It's time for wassup bro;";
        }


        //public ActionResult GetView()
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = "Alisha";
        //    emp.LastName = "Marla";
        //    emp.Salary = 4853;

        //    EmployeeViewModel vmEmp = new EmployeeViewModel();
        //    vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
        //    vmEmp.Salary = emp.Salary.ToString("C");
        //    if (emp.Salary > 5500)
        //    {
        //        vmEmp.SalaryColor = "yellow";
        //    }
        //    else
        //    {
        //        vmEmp.SalaryColor = "green";
        //    }

        //    return View("MyView", vmEmp);
        //}

        public ActionResult Index()
        {
            EmployeeListViewModel empListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach(Employee emp in employees)

            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if(emp.Salary>5000)
                { empViewModel.SalaryColor = "yellow"; }
                else
                { empViewModel.SalaryColor = "green"; }
                empViewModels.Add(empViewModel);
            }
           empListViewModel.Employees = empViewModels;
            empListViewModel.UserName = "Admin";
            return View("Index", empListViewModel);

        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch(BtnSubmit)
            {
                case "Save Employee":
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    empBal.SaveEmployee(e);
                    return RedirectToAction("Index");
                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
            
        }
    }
}