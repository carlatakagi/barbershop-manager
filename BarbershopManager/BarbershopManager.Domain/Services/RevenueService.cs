using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Entities;

namespace BarbershopManager.BarbershopManager.Domain.Services
{
    public interface IRevenueService
    {
        Task<IEnumerable<ResponseRevenue>> GetRevenue();
        Task<ResponseRevenue> GetRevenueById(Guid id);
        Task<Revenue> CreateRevenue(RequestCreate revenue);
    }
}
