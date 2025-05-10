using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllInExcelFormat;

public class GetAllCurrencyInExcelFormatQuery : IRequest<FileResult>
{
}
