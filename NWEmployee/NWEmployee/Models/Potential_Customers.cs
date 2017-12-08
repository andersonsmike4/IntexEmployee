using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NWEmployee.Models
{
    [Table("Potential_Customers")]
    public class Potential_Customers
    {
        [Key]
        [DisplayName("Potential ID")]
        public int potentialID { get; set; }

        [DisplayName("Company Name")]
        [Required]
        public string companyName { get; set; }

        [DisplayName("Contact Name")]
        [Required]
        public string ContactName { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string contactPhone { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string contactEmail { get; set; }

        [Required]
        [DisplayName("Notes")]
        public string notes { get; set; }
    }
}