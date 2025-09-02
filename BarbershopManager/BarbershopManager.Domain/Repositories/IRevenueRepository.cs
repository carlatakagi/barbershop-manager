using BarbershopManager.BarbershopManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarbershopManager.BarbershopManager.Domain.Repositories
{
    public interface IRevenueRepository
    {
        Task<Revenue> Create(Revenue revenue);
        Task<Revenue?> GetById(Guid id);
        Task<IEnumerable<Revenue>> GetAll();
        Task Delete(Guid id);
        Task<Revenue> Update(Revenue revenue);
    }
}
