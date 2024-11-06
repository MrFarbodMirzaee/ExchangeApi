using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;
public class AddExchangeTransactionCommandHandler : IRequestHandler<AddExchangeTransactionCommand, Response<bool>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public AddExchangeTransactionCommandHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(AddExchangeTransactionCommand request, CancellationToken ct)
    {
        var exchangetransaction = _mapper.Map<ExchangeApi.Domain.Entities.ExchangeTransaction>(request);
        var exchangeTransactionStatus = await _exchangeTranzacstionService.AddAsync(exchangetransaction, ct);
        return exchangeTransactionStatus.Succeeded ? new Response<bool>(exchangeTransactionStatus.Data) : new Response<bool>(exchangeTransactionStatus.Message);
    }
}
