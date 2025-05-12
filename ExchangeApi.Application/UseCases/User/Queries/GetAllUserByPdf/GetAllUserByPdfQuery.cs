using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUserByPdf;

public class GetAllUserByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}