using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;
public class UpdateExchangeTransactionCommandHandler : IRequestHandler<UpdateExchangeTransactionCommand, Response<bool>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public UpdateExchangeTransactionCommandHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(UpdateExchangeTransactionCommand request, CancellationToken ct)
    {
        request.ExchangeTransaction.Id = request.Id;
        request.ExchangeTransaction.Updated = DateTime.Now;

        Response<bool> exchangeTransactionStatus = await _exchangeTranzacstionService.UpdateAsync(request.ExchangeTransaction, ct);
        
        return exchangeTransactionStatus.Succeeded ? new Response<bool>(exchangeTransactionStatus.Data) : new Response<bool>(exchangeTransactionStatus.Message);
    }
}
