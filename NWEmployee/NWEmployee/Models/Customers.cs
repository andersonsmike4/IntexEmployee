using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NWEmployee.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [DisplayName("Customer ID")]
        public int custID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string custName { get; set; }

        [Required]
        [DisplayName("Address")]
        public string custAddress { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string custPhone { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string custEmail { get; set; }
    }
}