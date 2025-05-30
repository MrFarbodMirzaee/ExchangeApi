using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.UpdateExchangeRate;

public class UpdateExchangeRateCommandHandler(IExchangeRateService exchangeRateService,
    IValidator<UpdateExchangeRateCommand> updateExchangeRateCommandValidator,
    IMapper mapper)
    : IRequestHandler<UpdateExchangeRateCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateExchangeRateCommand request, CancellationToken ct)
    {
        await updateExchangeRateCommandValidator
        .ValidateAndThrowAsync(request,ct);
        
        var exchangeRateEntity = mapper
            .Map<Domain.Entities.ExchangeRate>
            (request.UpdateExchangeRateDto);
        
        exchangeRateEntity.Id = request.Id;
        exchangeRateEntity.Updated = DateTime.Now;

        var currencyStatus = await 
                            exchangeRateService
                            .UpdateAsync
                            (exchangeRateEntity, ct);

        return currencyStatus.Succeeded
            ? new Response<bool>(currencyStatus.Data)
            : new Response<bool>(currencyStatus.Message);
    }
}