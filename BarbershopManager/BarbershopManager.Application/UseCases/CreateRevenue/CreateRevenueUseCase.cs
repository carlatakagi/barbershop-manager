using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Domain.Services;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.CreateRevenue;

public class CreateRevenueUseCase : ICreateRevenue
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly IRevenueService _loggedRevenue;

    public CreateRevenueUseCase(IRevenueRepository repository, IMapper mapper, IRevenueService loggedRevenue)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedRevenue = loggedRevenue;
    }

    public async Task<ResponseRevenue> Execute(RequestCreate request)
    {
        var result = await _loggedRevenue.CreateRevenue(request);
        if (result is null)
        {
            throw new NotFoundException("Revenue not found");
        }

        return _mapper.Map<ResponseRevenue>(result);
    }
}
