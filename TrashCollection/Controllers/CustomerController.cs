using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult CustomerIndex()
        {
            string id = User.Identity.GetUserId();
            Customer customer = context.Customers.Where(e => e.ApplicationId == id).FirstOrDefault();
            
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult CreateCustomer()
        {
            Customer customer = new Customer(); 
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
          
            {

                string id = User.Identity.GetUserId();
                customer.ApplicationId = id;
                customer.WeeklyPickupDay = Convert.ToDateTime("12/12/2007");
                customer.EndDateForNoPickup = Convert.ToDateTime("12/12/2007"); 
                customer.SpecialPickUp = Convert.ToDateTime("12/12/2007");
                customer.StartDateForNoPickup = Convert.ToDateTime("12/12/2007");
                context.Customers.Add(customer);
                context.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("CustomerIndex");
            }
            
        }

        // GET: Customer/Edit/5
        public ActionResult EditPickupDates(int id)
        {
           Customer customer = context.Customers.Where(e => e.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int editId,Customer editedCustomer)
        {
            try
            {
               string id = User.Identity.GetUserId();
                Customer customer = context.Customers.Where(e => e.ApplicationId == id).FirstOrDefault();
                customer.WeeklyPickupDay = editedCustomer.WeeklyPickupDay;
                customer.EndDateForNoPickup = editedCustomer.EndDateForNoPickup;
                customer.SpecialPickUp = editedCustomer.SpecialPickUp;
                customer.StartDateForNoPickup = editedCustomer.StartDateForNoPickup; 
                context.SaveChanges();


                return RedirectToAction("CustomerIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
