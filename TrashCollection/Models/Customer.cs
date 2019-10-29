using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public string StreetAdress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Balance { get; set; }
        public int MonthleyCharge { get; set; }
        public bool PickupConfirmation { get; set; }
        public DateTime StartDateForNoPickup { get; set; }
        public DateTime EndDateForNoPickup { get; set; }
        public DateTime SpecialPickUp { get; set; }
        [ ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}