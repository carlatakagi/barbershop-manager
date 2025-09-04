using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;

public class GetRevenueByIdUseCase : IGetRevenueById
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;

    public GetRevenueByIdUseCase(IRevenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseRevenue> Execute(Guid id)
    {
        var result = await _repository.GetById(id);
        if (result is null)
        {
            throw new NotFoundException("Revenue not found");
        }

        return result;
    }
}
