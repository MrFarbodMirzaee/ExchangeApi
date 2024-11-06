using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;
public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Response<bool>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public UpdateCurrencyCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(UpdateCurrencyCommand request, CancellationToken ct)
    {
        request.Currency.Id = request.CurrencyId;
        request.Currency.Updated = DateTime.Now;

        var updatedCurrency = await _currencyService.UpdateAsync(request.Currency, ct);

        return updatedCurrency.Succeeded ? new Response<bool>(updatedCurrency.Data) : new Response<bool>(updatedCurrency.Message);
    }
}
