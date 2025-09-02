using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Entities;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Domain.Services;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue;
public class GetAllRevenueUseCase : IGetAllRevenue
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly IRevenueService _loggedRevenue;

    public GetAllRevenueUseCase(IRevenueRepository repository, IMapper mapper, IRevenueService loggedRevenue)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedRevenue = loggedRevenue;
    }

    public async Task<IEnumerable<ResponseRevenue>> Execute()
    {
        var revenues = await _loggedRevenue.GetRevenue();
        return _mapper.Map<IEnumerable<ResponseRevenue>>(revenues);
    }
}
}