using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Services;

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
    public async Task<IActionResult> GetExchangeTransactionById([FromRoute] int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        Response<List<ExchangeTransaction>> data = await _exchangeTranzacstionService.FindByCondition(x => x.Id == id);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeTransaction = _mapper.Map<ExchangeTransactionDto>(data);
        return Ok(new Response<ExchangeTransactionDto>(exchangeTransaction));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeTransactions()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        Response<List<ExchangeTransaction>> data = await _exchangeTranzacstionService.GetAllAsync();
        var ExchangeTranzactionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(new Response<List<ExchangeTransactionDto>>(ExchangeTranzactionDto));
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddExchangeTransaction(AddExchangeTransactionDto addExchangeTransaction)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        var exchangetransaction = _mapper.Map<ExchangeTransaction>(addExchangeTransaction);
        await _exchangeTranzacstionService.AddAsync(exchangetransaction);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsByCurrencyPair(int from_currencies,int to_currencies) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        Response<List<ExchangeTransaction>> data = await _exchangeTranzacstionService.FindByCondition(f => f.FromCurrencyId == from_currencies && f.ToCurrencyId == to_currencies);
        if (data is null) 
        {
            return NotFound(); 
        }
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(new Response<List<ExchangeTransactionDto>>(exchangeTranzacstionDto));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsById(int userid) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        Response<List<ExchangeTransaction>> data = await _exchangeTranzacstionService.FindByCondition(x => x.Id == userid);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(new Response<List<ExchangeTransactionDto>>(exchangeTranzacstionDto));
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTransactions(int userid)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        var exchangeTransactionsResponse = await _exchangeTranzacstionService.FindByCondition(x => x.Id == userid);
        if (!exchangeTransactionsResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return NotFound();
        }

        var exchangeTransactions = exchangeTransactionsResponse.Data.FirstOrDefault();

        var data = await _exchangeTranzacstionService.DeleteAsync(exchangeTransactions);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return StatusCode(500, data.Message);
        }
        var exchangeTranzacstionDto = _mapper.Map<bool>(data);
        return Ok(new Response<bool>(exchangeTranzacstionDto));
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTransactions(int id ,ExchangeTransaction exchangeTransaction)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        exchangeTransaction.Id = id;

        Response<bool> data = await _exchangeTranzacstionService.UpdateAsync(exchangeTransaction);
        var exchangeTranzacstionDto = _mapper.Map<ExchangeTransaction>(data);
        return Ok(new Response<ExchangeTransaction>(exchangeTranzacstionDto));
    }
}
