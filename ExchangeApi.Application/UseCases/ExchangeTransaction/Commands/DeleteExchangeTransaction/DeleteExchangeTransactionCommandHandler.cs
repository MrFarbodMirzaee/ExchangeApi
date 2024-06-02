

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExChangeApi.Domain.Entities;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;

public class DeleteExchangeTransactionCommandHandler : IRequestHandler<DeleteExchangeTransactionCommand, Response<int>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public DeleteExchangeTransactionCommandHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(DeleteExchangeTransactionCommand request, CancellationToken ct)
    {
        var exchangeTransactionsResponse = await _exchangeTranzacstionService.FindByCondition(x => x.Id == request.ExTId, ct);
        if (!exchangeTransactionsResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return new Response<int>(0, "Exchange transaction not found");
        }

        var exchangeTransactions = exchangeTransactionsResponse.Data.FirstOrDefault();

        var data = await _exchangeTranzacstionService.DeleteAsync(exchangeTransactions, ct);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return new Response<int>(0, "Exchange transaction not found");
        }
        var exchangeTranzacstionDto = _mapper.Map<bool>(data);
        return new Response<int>(1);
    }
}
