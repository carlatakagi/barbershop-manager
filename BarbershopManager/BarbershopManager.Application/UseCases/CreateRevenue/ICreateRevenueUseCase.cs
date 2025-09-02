using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Communication.Requests;

namespace BarbershopManager.BarbershopManager.Application.UseCases.CreateRevenue
{
    public interface ICreateRevenue
    {
        Task<ResponseRevenue> Execute(RequestCreate revenue);
    }
}
