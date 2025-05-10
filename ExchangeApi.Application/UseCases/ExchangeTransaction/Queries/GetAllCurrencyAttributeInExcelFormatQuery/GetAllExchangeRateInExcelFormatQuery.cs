using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllCurrencyAttributeInExcelFormatQuery;

public class GetAllExchangeTransactionInExcelFormatQuery : IRequest<FileResult>
{
}
