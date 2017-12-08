using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NWEmployee.Models
{
    [Table("Invoices")]
    public class Invoices
    {
        [Key]
        public int invoiceNo { get; set; }

        [Required]
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime? paymentDueDate { get; set; }

        [Required]
        [DisplayName("Early Payment Date")]
        [DataType(DataType.Date)]
        public DateTime? earlyPaymentDate { get; set; }

        [Required]
        [DisplayName("Early Payment Discount")]
        public decimal? earlyPaymentDiscount { get; set; }

        [Required]
        [DisplayName("Date Mailed")]
        [DataType(DataType.Date)]
        public DateTime? mailedDate { get; set; }

        [Required]
        [DisplayName("Total Payment")]
        public decimal? totalPayment { get; set; }

        [Required]
        [DisplayName("Total Paid")]
        public decimal? totalPaid { get; set; }

        [Required]
        [DisplayName("Balance")]
        public decimal? balance { get; set; }

        [Required]
        [DisplayName("One Time Discount")]
        public decimal? oneTimeDiscount { get; set; }
    }
}