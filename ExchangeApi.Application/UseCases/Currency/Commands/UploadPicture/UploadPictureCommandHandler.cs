
using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class UploadPictureCommandHandler : IRequestHandler<UploadPictureCommand, Response<int>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public UploadPictureCommandHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(UploadPictureCommand request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
        {
            return new Response<int>(0, "No file detected");
        }

        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream, cancellationToken);
            return new Response<int>(1, "File uploaded successfully");
        }
    }

}
