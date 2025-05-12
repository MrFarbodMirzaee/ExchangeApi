namespace ExchangeApi.Application.Contracts;

public interface IPdfService
{
    byte[] GeneratePdf<TEntity>(string title) where TEntity : class;
}