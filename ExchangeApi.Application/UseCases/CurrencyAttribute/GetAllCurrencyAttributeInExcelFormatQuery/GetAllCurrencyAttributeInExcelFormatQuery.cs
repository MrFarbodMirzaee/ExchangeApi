using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.GetAllCurrencyAttributeInExcelFormatQuery;

public class GetAllCurrencyAttributeInExcelFormatQuery : IRequest<FileResult>
{
}
