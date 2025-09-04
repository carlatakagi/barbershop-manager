using BarbershopManager.BarbershopManager.Domain.Enum;

namespace BarbershopManager.BarbershopManager.Communication.Requests
{
    public class RequestUpdate
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
