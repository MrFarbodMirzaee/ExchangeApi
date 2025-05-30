using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;

public class AddCurrencyCommandHandler(ICurrencyService currencyService,
    IMapper mapper,
    IValidator<AddCurrencyCommand> addCurrencyCommandValidator)
    : IRequestHandler<AddCurrencyCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddCurrencyCommand request, CancellationToken ct)
    {
        await addCurrencyCommandValidator
        .ValidateAndThrowAsync(request,ct);
        
        var currency = mapper
            .Map<Domain.Entities.Currency>
            (request);
        
        currency.Id = Guid.NewGuid();
        
        var currencyStatus = await 
            currencyService
            .AddAsync(currency, ct);
        
        return currencyStatus.Succeeded
            ? new Response<bool>(currencyStatus.Data)
            : new Response<bool>(currencyStatus.Message);
    }
}