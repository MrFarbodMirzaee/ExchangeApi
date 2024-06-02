

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Response<int>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public UpdateCurrencyCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(UpdateCurrencyCommand request, CancellationToken ct)
    {
        request.Currency.Id = request.CurrencyId;

        var updatedCurrency = await _currencyService.UpdateAsync(request.Currency, ct);

        var updatedCurrencyDto = _mapper.Map<ExChangeApi.Domain.Entities.Currency>(updatedCurrency); // Assuming CurrencyDto is the DTO for Currency

        return new Response<int>(1);
    }
}
