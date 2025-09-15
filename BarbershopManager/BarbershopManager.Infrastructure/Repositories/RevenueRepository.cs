using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;

namespace BarbershopManager.BarbershopManager.Infrastructure.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        public Task<ResponseCreateRevenue> Create(RequestCreate revenue)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseRevenue>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseRevenue?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUpdateRevenue> Update(RequestUpdate revenue)
        {
            throw new NotImplementedException();
        }
    }
}
