using BarbershopManager.BarbershopManager.Domain.Entities;

namespace BarbershopManager.BarbershopManager.Domain.Services
{
    public interface IRevenueService
    {
        Task<Revenue> GetRevenue();
        Task<Revenue> GetRevenueById(Guid id);
        Task<Revenue> CreateRevenue(Revenue revenue);
    }
}
