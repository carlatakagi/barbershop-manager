using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById
{
    public class GetRevenueByIdUseCase : IGetRevenueById
    {
        private readonly IRevenueRepository _repository;

        public GetRevenueByIdUseCase(IRevenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseRevenue> Execute(Guid id)
        {
            var result = await _repository.GetById(id);
            if (result is null)
            {
                throw new NotFoundException("Revenue not found");
            }

            // Repository already returns a ResponseRevenue DTO, return it directly
            return result;
        }
    }
}

