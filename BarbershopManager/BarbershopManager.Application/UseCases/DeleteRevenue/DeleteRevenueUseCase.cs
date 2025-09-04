using AutoMapper;
using BarbershopManager.BarbershopManager.Communication.Requests;
using BarbershopManager.BarbershopManager.Communication.Responses;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Domain.Services;
using Braintree.Exceptions;

namespace BarbershopManager.BarbershopManager.Application.UseCases.DeleteRevenue;

public class DeleteRevenueUseCase : IDeleteRevenue
{
    private readonly IRevenueRepository _repository;
    private readonly IMapper _mapper;
    private readonly IRevenueService _loggedRevenue;

    public DeleteRevenueUseCase(IRevenueRepository repository, IMapper mapper, IRevenueService loggedRevenue)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedRevenue = loggedRevenue;
    }

    public async Task Execute(Guid id)
    {
        await _repository.Delete(id);
    }
}
