﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "johnson";
            emp.LastName="fernanders";
            emp.Salary = 4000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 14000;
            employees.Add(emp);


            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = "patrick";
            emp.Salary = 1000;
            employees.Add(emp);

            return employees;
        }

        
      
    }
}