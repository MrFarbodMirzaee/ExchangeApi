

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;


namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public class AddExchangeRateCommandHandler : IRequestHandler<AddExchagneRateCommand, Response<int>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public AddExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
       
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(AddExchagneRateCommand request, CancellationToken ct)
    {
        var exchangeRateToCreate = _mapper.Map<ExchangeApi.Domain.Entities.ExchangeRate>(request);
        await _exchangeRateService.AddAsync(exchangeRateToCreate, ct);
        return new Response<int>();
    }
}
