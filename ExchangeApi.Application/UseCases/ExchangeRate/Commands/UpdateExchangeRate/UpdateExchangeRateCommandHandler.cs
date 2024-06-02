

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.Extensions.Options;
using System.Runtime;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public class UpdateExchangeRateCommandHandler : IRequestHandler<UpdateExchangeRateCommand, Response<int>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public UpdateExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(UpdateExchangeRateCommand request, CancellationToken ct)
    {
        request.ExchangeRate.Id = request.Id;

        Response<bool> data = await _exchangeRateService.UpdateAsync(request.ExchangeRate, ct);
        var exchangeRatesDto = _mapper.Map<ExchangeApi.Domain.Entities.ExchangeRate>(data);
        return new Response<int>(1);
    }
}
