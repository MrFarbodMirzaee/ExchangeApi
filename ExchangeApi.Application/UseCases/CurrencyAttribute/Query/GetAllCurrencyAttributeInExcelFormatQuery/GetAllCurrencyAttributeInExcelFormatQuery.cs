using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeInExcelFormatQuery;

public class GetAllCurrencyAttributeInExcelFormatQuery : IRequest<FileResult>
{
}
