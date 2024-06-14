using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;

namespace ExchangeApi.Controllers.V1;

public class ExchangeTransactionController : BaseController
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public ExchangeTransactionController(IExchangeTransactionServices exchangeTranzacstionService,IMapper mapper,IOptionsMonitor<MySettings> settings, IIpAddresssValdatorServices ipAddresssValdatorClass)
    {
        _settings = settings.CurrentValue;
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
        _ipAddresssValdatorClass = ipAddresssValdatorClass;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] GetExchangeTransactionByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll( GetAllExchangeTransactionQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(AddExchangeTransactionCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCurrencyPair(GetExchangeTransactionByCurrencyPairQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Transactions(DeleteExchangeTransactionCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(UpdateExchangeTransactionCommand request,CancellationToken ct) => await SendAsync(request, ct);
}
