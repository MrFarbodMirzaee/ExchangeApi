using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRate;

public class GetAllExchangeRateQueryHandler(IExchangeRateService exchangeRateService,
    IValidator<GetAllExchangeRateQuery> getAllExchangeRateQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetAllExchangeRateQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetAllExchangeRateQuery request, CancellationToken ct)
    {
        await getAllExchangeRateQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
        var exchangeRate =
            await exchangeRateService.FindByQueryCriteria
                    (request.QueryCriteria,ct);
        
        var exchangeRateMapped = mapper.Map
                    <List<ExchangeRateDto>>
                        (exchangeRate.Data);
        
        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>
                                (exchangeRateMapped)
            : new Response<List<ExchangeRateDto>>
                                (exchangeRate.Message);
    }
}