using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, Response<int>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public DeleteCurrencyCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(DeleteCurrencyCommand request, CancellationToken ct)
    {
        var currencyResponse = await _currencyService.FindByCondition(x => x.Id == request.CurrencyId, ct);
        if (!currencyResponse.Succeeded || currencyResponse.Data is null || currencyResponse.Data.Count == 0)
        {
            return new Response<int>(0, "Currency not found");
        }

        var currency = currencyResponse.Data.FirstOrDefault();
        var deleteResponse = await _currencyService.DeleteAsync(currency, ct);
        if (!deleteResponse.Succeeded)
        {
            return new Response<int>(0, deleteResponse.Message);
        }

        return new Response<int>(1);
    }

}
