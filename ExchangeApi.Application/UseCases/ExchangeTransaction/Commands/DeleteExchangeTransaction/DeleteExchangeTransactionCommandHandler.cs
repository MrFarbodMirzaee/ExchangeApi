using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;
public class DeleteExchangeTransactionCommandHandler : IRequestHandler<DeleteExchangeTransactionCommand, Response<bool>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public DeleteExchangeTransactionCommandHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(DeleteExchangeTransactionCommand request, CancellationToken ct)
    {
        var exchangeTransactionsFind = await _exchangeTranzacstionService.FindByCondition(x => x.Id == request.Id, ct);

        if (!exchangeTransactionsFind.Succeeded)
            return new Response<bool>(exchangeTransactionsFind.Message);

        var exchangeTransactions = exchangeTransactionsFind.Data.FirstOrDefault();

        var exchangeTransactionsStatus = await _exchangeTranzacstionService.DeleteAsync(exchangeTransactions, ct);
   
        var exchangeTranzacstionDto = _mapper.Map<bool>(exchangeTransactionsStatus.Data);

        return exchangeTransactionsStatus.Succeeded ? new Response<bool>(exchangeTranzacstionDto) : new Response<bool>(exchangeTransactionsStatus.Message);
    }
}
