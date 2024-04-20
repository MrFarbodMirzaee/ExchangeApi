

namespace ExchangeApi.Application.Dtos
{
    public record class CurrencyDto 
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
    }
}
