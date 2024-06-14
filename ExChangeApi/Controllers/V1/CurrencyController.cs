using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ExchangeApi.Shered;
using System.Net.Mime;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.Currency.Commands;
using ExchangeApi.Application.UseCases.Currency.Queries.GetActiveCurrency;
using ExchangeApi.Application.UseCases.Currency.Queries;
using ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;

namespace ExchangeApi.Controllers.V1;

public class CurrencyController : BaseController
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public CurrencyController(ICurrencyService currencyService, IMapper mapper,IOptionsMonitor<MySettings> settings, IIpAddresssValdatorServices ipAddresssValdatorClass)
    {
        _settings = settings.CurrentValue;
        _currencyService = currencyService;
        _mapper = mapper;
        _ipAddresssValdatorClass = ipAddresssValdatorClass;
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(GetAllCurrencyQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActive(GetCurrencyActiveQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(GetCurrencyByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddCurrencyCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search(SearchCurrencyQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteCurrencyCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(UpdateCurrencyCommand request, CancellationToken ct) => await SendAsync(request,ct);
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadPicture(UploadPictureCommand request, CancellationToken ct) => await SendAsync(request, ct);
    
}
