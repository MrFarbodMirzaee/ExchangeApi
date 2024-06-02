using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Shered;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries;
using ExchangeApi.Application.UseCases.ExchangeRate;

namespace ExchangeApi.Controllers.V1;

public class ExchangeRateController : BaseController
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public ExchangeRateController(IExchangeRateService exchangeRateService,IMapper mapper,IOptionsMonitor<MySettings> settings, IIpAddresssValdatorServices ipAddresssValdatorClass)
    {
        _settings = settings.CurrentValue;
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
        _ipAddresssValdatorClass = ipAddresssValdatorClass;
    }


    [Route("{id}")]
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeRateById([FromRoute] GetExchangeRateByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeRates(GetAllExchangeRateQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddExchangeRate([FromBody] AddExchagneRateCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeRatesByCurrencyPair(GetExchangeRateByCurrencyPairQuery request, CancellationToken ct) => await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatestExchangeRate(GetLatestExchangeRateQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteExchangeRate(DeleteExchangeRateCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateExchangeRate(UpdateExchangeRateCommand request, CancellationToken ct) => await SendAsync(request, ct);
    
}
