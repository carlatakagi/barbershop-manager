using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Communication.Requests;

namespace BarbershopManager.BarbershopManager.Application.UseCases.UpdateRevenue
{
    public interface IUpdateRevenue
    {
        Task<ResponseRevenue> Execute(RequestUpdate revenue);
    }
}
