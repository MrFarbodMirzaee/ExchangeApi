using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UpdateCurrency;

public class UpdateCurrencyCommandHandler(ICurrencyService currencyService,IMapper mapper)
    : IRequestHandler<UpdateCurrencyCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateCurrencyCommand request, CancellationToken ct)
    {
        var currencyEntity = mapper.Map<Domain.Entities.Currency>(request.UpdateCurrencyDto);
            
        currencyEntity.Id = request.CurrencyId;
        currencyEntity.Updated = DateTime.Now;

        var updatedCurrency = await currencyService.UpdateAsync(currencyEntity, ct);

        return updatedCurrency.Succeeded
            ? new Response<bool>(updatedCurrency.Data)
            : new Response<bool>(updatedCurrency.Message);
    }
}