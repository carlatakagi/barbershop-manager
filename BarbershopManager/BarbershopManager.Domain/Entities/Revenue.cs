using System;
using BarbershopManager.BarbershopManager.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BarbershopManager.BarbershopManager.Domain.Entities
{
    public class Revenue
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }
    }
}
