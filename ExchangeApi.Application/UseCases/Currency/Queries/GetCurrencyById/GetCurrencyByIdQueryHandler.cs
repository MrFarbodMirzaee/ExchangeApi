using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyById;

public class GetCurrencyByIdQueryHandler(ICurrencyService currencyService,
    IValidator<GetCurrencyByIdQuery> getCurrencyByIdQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetCurrencyByIdQuery, Response<List<CurrencyDto>>>
{
    public async Task<Response<List<CurrencyDto>>> Handle(GetCurrencyByIdQuery request, CancellationToken ct)
    {
        await getCurrencyByIdQueryValidator
        .ValidateAndThrowAsync(request, ct);
        
        Response<List<Domain.Entities.Currency>> currency =
            await currencyService.FindByCondition(x => x.Id == request.CurrencyId, ct);

        var currencyMapped = mapper.Map<List<CurrencyDto>>(currency.Data);
        return currency.Succeeded
            ? new Response<List<CurrencyDto>>(currencyMapped)
            : new Response<List<CurrencyDto>>(currency.Message);
    }
}