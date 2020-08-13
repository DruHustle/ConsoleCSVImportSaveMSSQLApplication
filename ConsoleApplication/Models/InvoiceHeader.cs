using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI.Models
{
    public class InvoiceHeader
    {
        [Key]
        public int InvoiceId { get; set; }

        [MaxLength(50)]
        [Required]
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }
        public float InvoiceTotal { get; set; }
    }
}
