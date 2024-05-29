using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;


namespace Exchange.gRPCServer.Services;

public class gRPCCurrencyService
{
    public gRPCCurrencyService() { }
    private readonly AppDbContext _appDbContext;
    public gRPCCurrencyService(AppDbContext appDbContext) 
    {
        _appDbContext = appDbContext;
    }
    public async Task GetCurrency(GetCurrencyRequestDto request, IServerStreamWriter<CurrencyResponseDto> responseStream, ServerCallContext context)
    {

        var data = await _appDbContext.currencies.Where(x => x.Id == x.Id).ToListAsync();
        foreach (var currency in data)
        {
             await responseStream.WriteAsync(new CurrencyResponseDto
            {
                CurrencyCode = currency.CurrencyCode,
                Price = currency.Price
            });
        }
    }
}

