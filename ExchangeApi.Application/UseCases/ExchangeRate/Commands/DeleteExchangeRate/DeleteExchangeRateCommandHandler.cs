using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.DeleteExchangeRate;

public class DeleteExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    : IRequestHandler<DeleteExchangeRateCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteExchangeRateCommand request, CancellationToken ct)
    {
        var exchangeRateFind = await exchangeRateService.FindByCondition(x => x.Id == request.Id, ct);
        if (!exchangeRateFind.Succeeded)
            return new Response<bool>(exchangeRateFind.Message);

        var exchangeRate = exchangeRateFind.Data.FirstOrDefault();

        if (exchangeRate is null)
            return new Response<bool>(false);

        var deleted = await exchangeRateService.DeleteAsync(exchangeRate, ct);

        var exchangeRatesDto = mapper.Map<bool>(deleted.Data);

        return deleted.Succeeded ? new Response<bool>(exchangeRatesDto) : new Response<bool>(deleted.Message);
    }
}