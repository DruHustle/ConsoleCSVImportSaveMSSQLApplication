using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleUI.Models
{
    public class InvoiceLine
    {
        [Key]
        public int LineId { get; set; }

        [MaxLength(50)]
        [Required]
        public string InvoiceNumber { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public float Quantity { get; set; }
        public float UnitSellingPriceExVAT { get; set; }

    }
}
