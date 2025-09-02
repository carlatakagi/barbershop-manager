using BarbershopManager.BarbershopManager.Communication.Responses;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue
{
    public interface IGetAllRevenue
    {
        Task<IEnumerable<ResponseRevenue>> Execute();
    }
}
