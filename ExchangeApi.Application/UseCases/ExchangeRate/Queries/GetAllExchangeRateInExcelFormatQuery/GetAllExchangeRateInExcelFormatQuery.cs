using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRateInExcelFormatQuery;

public class GetAllExchangeRateInExcelFormatQuery : IRequest<FileResult>
{
}
