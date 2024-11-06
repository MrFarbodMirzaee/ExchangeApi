using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;
public class AddExchangeRateCommandHandler : IRequestHandler<AddExchagneRateCommand, Response<bool>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public AddExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(AddExchagneRateCommand request, CancellationToken ct)
    {
        var exchangeRateMapped = _mapper.Map<ExchangeApi.Domain.Entities.ExchangeRate>(request);
        var exchangeRateStatus = await _exchangeRateService.AddAsync(exchangeRateMapped, ct);
        return exchangeRateStatus.Succeeded == true ? new Response<bool>(exchangeRateStatus.Data) : new Response<bool>(exchangeRateStatus.Message);
    }
}
