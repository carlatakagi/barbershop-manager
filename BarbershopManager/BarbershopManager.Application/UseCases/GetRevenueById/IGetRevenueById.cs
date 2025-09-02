using BarbershopManager.BarbershopManager.Communication.Responses;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById
{
    public interface IGetRevenueById
    {
        Task<ResponseRevenue> Execute();
    }
}
