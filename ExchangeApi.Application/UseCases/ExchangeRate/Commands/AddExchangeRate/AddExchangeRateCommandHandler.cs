using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;

public class AddExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    : IRequestHandler<AddExchangeRateCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddExchangeRateCommand request, CancellationToken ct)
    {
        var exchangeRateMapped = mapper.Map<ExchangeApi.Domain.Entities.ExchangeRate>(request);
        var exchangeRateStatus = await exchangeRateService.AddAsync(exchangeRateMapped, ct);
        return exchangeRateStatus.Succeeded == true
            ? new Response<bool>(exchangeRateStatus.Data)
            : new Response<bool>(exchangeRateStatus.Message);
    }
}