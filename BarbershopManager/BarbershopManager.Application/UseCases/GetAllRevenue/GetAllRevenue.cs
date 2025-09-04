using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;

namespace BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue;

public class GetAllRevenueUseCase : IGetAllRevenue
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRevenueUseCase(IRevenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ResponseRevenue>> Execute()
    {
        var revenues = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ResponseRevenue>>(revenues);
    }
}