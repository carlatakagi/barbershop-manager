using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.DeleteRevenue
{
    public class DeleteRevenueUseCase : IDeleteRevenue
    {
        private readonly IRevenueRepository _repository;
        private readonly IMapper _mapper;

        public DeleteRevenueUseCase(IRevenueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Execute(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}
