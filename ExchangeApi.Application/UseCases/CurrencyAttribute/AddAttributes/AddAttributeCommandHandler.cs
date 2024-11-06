using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute;
public class AddAttributeCommandHandler : IRequestHandler<AddAttributeCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly ICurrencyAttributeService _currencyService;
    public AddAttributeCommandHandler(IMapper mapper, ICurrencyAttributeService currencyService)
    {
        _mapper = mapper;
        _currencyService = currencyService;
    }
    public async Task<Response<bool>> Handle(AddAttributeCommand request, CancellationToken ct)
    {
        var currencyAttribute = _mapper.Map<ExchangeApi.Domain.Entities.CurrencyAttribute>(request);
        var currencyAttributeStatus = await _currencyService.AddAsync(currencyAttribute,ct);
        return currencyAttributeStatus.Data == true ? new Response<bool>(true) : new Response<bool>(false);
    }
}
