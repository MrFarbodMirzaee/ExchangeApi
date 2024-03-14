using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class ExchangeTransactionContoller : BaseContoller
{
    private readonly IExchangeTransactionBusiness _exchangeTranzacstionBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    public ExchangeTransactionContoller(IExchangeTransactionBusiness exchangeTranzacstionBusiness,IMapper mapper,IOptionsMonitor<MySettings> settings)
    {
        _settings = settings.CurrentValue;
        _exchangeTranzacstionBusiness = exchangeTranzacstionBusiness;
        _mapper = mapper;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeTransactionById([FromRoute] int id)
    {
        var data = _exchangeTranzacstionBusiness.GetExchangeTransactionById(id);
        var exchangeTransaction = _mapper.Map<ExchangeTransactionDto>(data);
        return Ok(exchangeTransaction);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeTransactions()
    {
        var data = _exchangeTranzacstionBusiness.GetAllExchangeTransactions();
        var ExchangeTranzactionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(ExchangeTranzactionDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddExchangeTransaction([FromBody] ExchangeTransactionDto addExchangeTransaction)
    {
        var exchangetransaction = _mapper.Map<ExchangeTransaction>(addExchangeTransaction);
        _exchangeTranzacstionBusiness.CreateExchangeTransaction(exchangetransaction);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsByCurrencyPair(int from_currencies,int to_currencies) 
    {
        var data = _exchangeTranzacstionBusiness.GetTransactionsByCurrencyPair(from_currencies,to_currencies);
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransaction>>(data);
        return Ok(exchangeTranzacstionDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsByUserId(int userid) 
    {
        var data = _exchangeTranzacstionBusiness.GetTransactionsByUserId(userid);
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(exchangeTranzacstionDto);
    }
}
