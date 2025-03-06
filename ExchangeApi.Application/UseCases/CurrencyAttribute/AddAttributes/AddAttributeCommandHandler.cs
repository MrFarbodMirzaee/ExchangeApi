using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;

public class AddAttributeCommandHandler(IMapper mapper, ICurrencyAttributeService currencyService)
    : IRequestHandler<AddAttributeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddAttributeCommand request, CancellationToken ct)
    {
        var currencyAttribute = mapper.Map<ExchangeApi.Domain.Entities.CurrencyAttribute>(request);
        var currencyAttributeStatus = await currencyService.AddAsync(currencyAttribute, ct);
        return currencyAttributeStatus.Data == true ? new Response<bool>(true) : new Response<bool>(false);
    }
}