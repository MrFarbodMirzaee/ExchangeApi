using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRate;

public class GetAllExchangeRateQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    : IRequestHandler<GetAllExchangeRateQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetAllExchangeRateQuery request, CancellationToken ct)
    {
        int pageSize = request.PageSize;
        int page = request.Page;
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate =
            await exchangeRateService.GetAllAsync(ct, page, pageSize);
        var exchangeRateMapped = mapper.Map<List<ExchangeRateDto>>(exchangeRate.Data);
        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>(exchangeRateMapped)
            : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}