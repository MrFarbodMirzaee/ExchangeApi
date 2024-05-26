using Exchange.gRPCServer.Models;
using Exchange.gRPCServer.Protos;
using Grpc.Core;

namespace Exchange.gRPCServer.Services;

public class gRPCCurrencyService : CurrencyRepository.CurrencyRepositoryBase
{
    public gRPCCurrencyService() { }
    public override Task<CurrencyResponseDto> GetCurrency(GetCurrencyRequestDto request, ServerCallContext context)
    {
        List<Currency> currencies = new List<Currency>()
        {
            new Currency(){ Id = 1 , CurrencyCode = "USD",Price ="1.54548874" },
            new Currency(){ Id = 2 , CurrencyCode = "ERU",Price ="0.21458"},
            new Currency(){ Id = 3 , CurrencyCode = "PUD",Price ="0.418548"},
        };
        var data = currencies.Where(x => x.Id == x.Id).FirstOrDefault();
        return Task.FromResult(new CurrencyResponseDto()
        {

            CurrencyCode = data.CurrencyCode,
            Price = data.Price
        });
    }
}

