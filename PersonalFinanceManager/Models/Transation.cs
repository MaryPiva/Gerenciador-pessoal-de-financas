using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Type { get; set; } // "income" or "expense"

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
