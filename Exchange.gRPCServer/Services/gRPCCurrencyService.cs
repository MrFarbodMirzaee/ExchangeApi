using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Entities;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Services;

public class GrpcCurrencyService(AppDbContext appDbContext) : CurrencyRepository.CurrencyRepositoryBase
{
    public override async Task<AddCurrencyResponseDto> AddCurrency(AddCurrencyRequestDto request,
        ServerCallContext context)
    {
        try
        {
            if ((request.CurrencyCode.Length < 3 || string.IsNullOrEmpty(request.CurrencyCode)) &&
                (request.Price == null || request.Price == 0))
            {
                return new AddCurrencyResponseDto()
                {
                    ErrorMessage = "Please Enter Correct Format"
                };
            }

            var data = new Currency()
            {
                CurrencyCode = request.CurrencyCode,
                Price = request.Price,
            };
            await appDbContext.Currency.AddAsync(data);
            await appDbContext.SaveChangesAsync();
            return new AddCurrencyResponseDto()
            {
                AddedMessage = "Currency Added"
            };
        }
        catch (Exception ex)
        {
            return new AddCurrencyResponseDto()
            {
                ErrorMessage = $"{ex.Message}"
            };
        }
    }

    public override async Task<DeleteCurrencyResponseDto> DeleteCurrency(DeleteCurrencyRequestDto request,
        ServerCallContext context)
    {
        try
        {
            var currency = await appDbContext.Currency.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (currency == null)
            {
                return new DeleteCurrencyResponseDto
                {
                    DeletedMessage = "not deleted",
                    ErrorMessage = $"Currency with ID {request.Id} not found."
                };
            }

            appDbContext.Currency.Remove(currency);
            await appDbContext.SaveChangesAsync();

            return new DeleteCurrencyResponseDto
            {
                DeletedMessage = "Deleted"
            };
        }
        catch (Exception ex)
        {
            return new DeleteCurrencyResponseDto
            {
                ErrorMessage = $"Error deleting currency: {ex.Message}"
            };
        }
    }

    public override async Task<CurrencyResponseDto> GetCurrencyById(GetCurrencyByIdRequestDto request,
        ServerCallContext context)
    {
        var data = await appDbContext.Currency.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        if (data is null)
        {
            return new CurrencyResponseDto
            {
                ErrorMessage = "Currency not found"
            };
        }

        return new CurrencyResponseDto()
        {
            CurrencyCode = data.CurrencyCode,
            Price = data.Price,
        };
    }

    public override async Task<UpdateCurrencyResponseDto> UpdateCurrency(UpdateCurrencyRequestDto request,
        ServerCallContext context)
    {
        var currencyData = await appDbContext.Currency.FirstOrDefaultAsync(c => c.Id == request.Id);
        if (currencyData is null)
        {
            return new UpdateCurrencyResponseDto
            {
                ErrorMessage = "Currency not found"
            };
        }
        else
        {
            currencyData.CurrencyCode = request.CurrencyCode;
            currencyData.Price = request.Price;
            await appDbContext.SaveChangesAsync();

            return new UpdateCurrencyResponseDto
            {
                UpdatedMessage = $"Currency with ID {request.Id} has been updated."
            };
        }
    }
}