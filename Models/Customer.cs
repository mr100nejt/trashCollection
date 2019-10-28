using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int zipCode { get; set; }
        public string streetAdress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int balance { get; set; }
        public int monthleyCharge { get; set; }
        public bool pickupConfirmation { get; set; }
        public string startDateForNoPickup { get; set; }
        public string endDateForNoPickup { get; set; }

    }
}