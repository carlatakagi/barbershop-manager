using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluent.Infrastructure.FluentModel;

namespace BarbershopManager.BarbershopManager.Infra.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly ApplicationDbContext _context;

        public RevenueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseCreateRevenue> Create(RequestCreate revenue)
        {
            // lógica para persistir no banco
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            // lógica para deletar do banco
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResponseRevenue>> GetAll()
        {
            // lógica para buscar todos os registros
            throw new NotImplementedException();
        }

        public async Task<ResponseRevenue?> GetById(Guid id)
        {
            // lógica para buscar por id
            throw new NotImplementedException();
        }

        public async Task<ResponseUpdateRevenue> Update(RequestUpdate revenue)
        {
            // lógica para atualizar o registro
            throw new NotImplementedException();
        }
    }
}
