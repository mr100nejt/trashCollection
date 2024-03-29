﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
   
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        ApplicationDbContext zipList;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
            zipList = new ApplicationDbContext(); 
        }

        // GET: Employee
        public ActionResult EmployeeIndex(string searchDay)
        {
           
            
                string id = User.Identity.GetUserId();
                Employee employee = context.Employees.Where(e => e.ApplicationId == id).FirstOrDefault();
                
                var customersToAdd = context.Customers.Where(e => e.ZipCode == employee.ZipCode ).AsEnumerable();
            

            return View(customersToAdd);
        }

        // GET: Employee/Details/5
        public ActionResult CustomersByDay()
        {
            string id = User.Identity.GetUserId();
            var curentDate = DateTime.Today;
           
          var customersToAdd = context.Customers.Where(e => e.WeeklyPickupDay == curentDate).AsEnumerable();
         
         
            return View(customersToAdd);
        }

        // GET: Employee/Create
        public ActionResult CreateEmployee()
        {
            Employee employee = new Employee(); 
            
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {
                string id = User.Identity.GetUserId();
                employee.ApplicationId = id; 
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("EmployeeIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult PickUpConfirmation(int id)
        {
            Customer customer = context.Customers.Where(e => e.Id == id).FirstOrDefault(); 
            return View(customer);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult PickUpConfirmationt(int id, Customer EditedCustomer)
        {
            try
            {
                Customer customer = context.Customers.Where(e => e.Id == id).FirstOrDefault();
                customer.PickupConfirmation = EditedCustomer.PickupConfirmation;
                customer.MonthleyCharge = EditedCustomer.MonthleyCharge;
                customer.Balance = EditedCustomer.Balance;

                return RedirectToAction("EmployeeIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
