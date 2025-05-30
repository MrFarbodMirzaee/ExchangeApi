using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateById;

public class GetExchangeRateByIdQueryHandler(IExchangeRateService exchangeRateService,
    IValidator<GetExchangeRateByIdQuery> getExchangeRateByIdQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetExchangeRateByIdQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetExchangeRateByIdQuery request, CancellationToken ct)
    {
        await getExchangeRateByIdQueryValidator.
        ValidateAndThrowAsync(request, ct);
        
        var exchangeRate =
            await exchangeRateService
            .FindByCondition(x => x.Id == request.Id, ct);

        var exchangeRateMapped = mapper
            .Map<List<ExchangeRateDto>>
            (exchangeRate.Data);

        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>(exchangeRateMapped)
            : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}