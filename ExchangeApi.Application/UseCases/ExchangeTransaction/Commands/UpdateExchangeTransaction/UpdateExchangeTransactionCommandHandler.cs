using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;

public class UpdateExchangeTransactionCommandHandler : IRequestHandler<UpdateExchangeTransactionCommand, Response<int>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public UpdateExchangeTransactionCommandHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(UpdateExchangeTransactionCommand request, CancellationToken ct)
    {
        request.ExchangeTransaction.Id = request.Id;
        Response<bool> data = await _exchangeTranzacstionService.UpdateAsync(request.ExchangeTransaction, ct);
        var exchangeTranzacstionDto = _mapper.Map<ExchangeApi.Domain.Entities.ExchangeTransaction>(data.Data);
        return new Response<int>(1);
    }
}
