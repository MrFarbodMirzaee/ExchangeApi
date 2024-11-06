using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;
public class UpdateExchangeRateCommandHandler : IRequestHandler<UpdateExchangeRateCommand, Response<bool>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public UpdateExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(UpdateExchangeRateCommand request, CancellationToken ct)
    {
        request.ExchangeRate.Id = request.Id;
        request.ExchangeRate.Updated = DateTime.Now;

        Response<bool> currencyStatus = await _exchangeRateService.UpdateAsync(request.ExchangeRate, ct);

        return currencyStatus.Succeeded ? new Response<bool>(currencyStatus.Data) : new Response<bool>(currencyStatus.Message);
    }
}
