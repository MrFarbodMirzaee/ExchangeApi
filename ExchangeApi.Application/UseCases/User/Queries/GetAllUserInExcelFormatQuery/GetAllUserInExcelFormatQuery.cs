using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUserInExcelFormatQuery;

public class GetAllUserInExcelFormatQuery : IRequest<FileResult>
{
}
