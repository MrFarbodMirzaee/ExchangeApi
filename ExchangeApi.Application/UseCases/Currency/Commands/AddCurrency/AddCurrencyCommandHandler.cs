using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;


namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class AddCurrencyCommandHandler : IRequestHandler<AddCurrencyCommand, Response<int>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
   
    public AddCurrencyCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;  
    }
    public async Task<Response<int>> Handle(AddCurrencyCommand request, CancellationToken ct)
    {

        var currency = _mapper.Map<ExChangeApi.Domain.Entities.Currency>(request);
        await _currencyService.AddAsync(currency, ct);
        return new Response<int>();
    }
}
