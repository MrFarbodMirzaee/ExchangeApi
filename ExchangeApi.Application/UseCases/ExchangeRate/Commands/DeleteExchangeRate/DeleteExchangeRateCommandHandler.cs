
using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public class DeleteExchangeRateCommandHandler : IRequestHandler<DeleteExchangeRateCommand,Response<int>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public DeleteExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(DeleteExchangeRateCommand request, CancellationToken ct)
    {
        var exchangeRateResponse = await _exchangeRateService.FindByCondition(x => x.Id == request.Id, ct);
        if (!exchangeRateResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return new Response<int>(0, "Exchange rate not found");
        }

        var exchangeRate = exchangeRateResponse.Data.FirstOrDefault();

        var data = await _exchangeRateService.DeleteAsync(exchangeRate, ct);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return new Response<int>(0, data.Message);
        }
        var exchangeRatesDto = _mapper.Map<bool>(data);
        return new Response<int>(1);
    }
}
