using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Services;

public class GrpcStreamingCurrencyService(AppDbContext appDbContext)
    : CurrencyStreamRepository.CurrencyStreamRepositoryBase
{
    public async Task GetAllCurrency(GetCurrencyStraminRequestDto request,
        IServerStreamWriter<CurrencyStreamResponse> responseStream, ServerCallContext context)
    {
        var data = await appDbContext.Currency.ToListAsync();
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