using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarbershopManager.BarbershopManager.Domain.Repositories
{
    public interface IRevenueRepository
    {
        Task<ResponseCreateRevenue> Create(RequestCreate revenue);
        Task<ResponseRevenue?> GetById(Guid id);
        Task<IEnumerable<ResponseRevenue>> GetAll();
        Task Delete(Guid id);
        Task<ResponseUpdateRevenue> Update(RequestUpdate revenue);
    }
}
