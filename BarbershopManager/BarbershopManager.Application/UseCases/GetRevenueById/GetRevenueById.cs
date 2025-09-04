using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Domain.Services;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;

public class GetRevenueByIdUseCase : IGetRevenueById
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly IRevenueService _loggedRevenue;

    public GetRevenueByIdUseCase(IRevenueRepository repository, IMapper mapper, IRevenueService loggedRevenue)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedRevenue = loggedRevenue;
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
