using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;
public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, Response<bool>>
{
    private readonly ICurrencyService _currencyService;
    public DeleteCurrencyCommandHandler(ICurrencyService currencyService) => _currencyService = currencyService;
    
    public async Task<Response<bool>> Handle(DeleteCurrencyCommand request, CancellationToken ct)
    {
        var currencyFind = await _currencyService.FindByCondition(x => x.Id == request.CurrencyId, ct);

        if (currencyFind.Data is null)
            return new Response<bool>(currencyFind.Message);

        var currency = currencyFind.Data.FirstOrDefault();
        if (currency is null)
            return new Response<bool>(false);

        var deleted = await _currencyService.DeleteAsync(currency, ct);

        return deleted.Succeeded ? new Response<bool>(deleted.Data) : new Response<bool>(deleted.Message);
    }

}
