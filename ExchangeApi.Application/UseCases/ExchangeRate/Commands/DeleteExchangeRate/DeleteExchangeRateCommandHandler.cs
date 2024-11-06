using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;
public class DeleteExchangeRateCommandHandler : IRequestHandler<DeleteExchangeRateCommand,Response<bool>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public DeleteExchangeRateCommandHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(DeleteExchangeRateCommand request, CancellationToken ct)
    {
        var exchangeRateFind = await _exchangeRateService.FindByCondition(x => x.Id == request.Id, ct);
        if (!exchangeRateFind.Succeeded)
            return new Response<bool>(exchangeRateFind.Message);

        var exchangeRate = exchangeRateFind.Data.FirstOrDefault();

        if (exchangeRate is null)
        return new Response<bool>(false);

        var deleted = await _exchangeRateService.DeleteAsync(exchangeRate, ct);
        
        var exchangeRatesDto = _mapper.Map<bool>(deleted.Data);

        return deleted.Succeeded ? new Response<bool>(exchangeRatesDto) : new Response<bool>(deleted.Message);
    }
}
