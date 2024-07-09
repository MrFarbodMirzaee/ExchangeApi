using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Services;

public class GrpcStreamingCurrencyService : CurrencyStreamRepository.CurrencyStreamRepositoryBase
{
    private readonly AppDbContext _appDbContext;

    public GrpcStreamingCurrencyService(AppDbContext appDbContext) => _appDbContext = appDbContext;
    public async override Task GetAllCurrrency(GetCurrencyStraminRequestDto request, IServerStreamWriter<CurrencyStreamResponse> responseStream, ServerCallContext context)
    {
        var data = await _appDbContext.Currency.ToListAsync();
        foreach (var item in data) 
        {
            await responseStream.WriteAsync(new CurrencyStreamResponse
            {
                Id = item.Id,
                CurrencyCode = item.CurrencyCode,
                Price = item.Price
            });
        }
    }
}
