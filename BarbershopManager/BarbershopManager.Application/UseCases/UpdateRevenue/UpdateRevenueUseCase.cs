using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.UpdateRevenue;

public class UpdateRevenueUseCase : IUpdateRevenue
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;

    public UpdateRevenueUseCase(IRevenueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseRevenue> Execute(RequestUpdate request)
    {
        var result = await _repository.Update(request) ?? throw new NotFoundException("Revenue not found");
        return _mapper.Map<ResponseRevenue>(result);
    }
}
