using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;
public class AddCurrencyCommandHandler : IRequestHandler<AddCurrencyCommand, Response<bool>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    public AddCurrencyCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(AddCurrencyCommand request, CancellationToken ct)
    {
        var currency = _mapper.Map<ExChangeApi.Domain.Entities.Currency>(request);
        var currencyStatus = await _currencyService.AddAsync(currency, ct);
        return currencyStatus.Succeeded ? new Response<bool>(currencyStatus.Data) : new Response<bool>(currencyStatus.Message);
    }
}
