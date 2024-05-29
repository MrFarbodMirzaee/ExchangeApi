using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Shered;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Infrustructure.Services;

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
    public async Task<IActionResult> GetExchangeRateById([FromRoute] int id, CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        Response<List<ExchangeRate>> data = await _exchangeRateService.FindByCondition(x => x.Id == id, ct);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeRateDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(new Response<ExchangeRateDto>(exchangeRateDto));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeRates(CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
       

        Response<List<ExchangeRate>> data = await _exchangeRateService.GetAllAsync(ct);
        var exchangeRateDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(new Response<List<ExchangeRateDto>>(exchangeRateDto));
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddExchangeRate([FromBody] AddExchangeRateDto addExchangeRate,CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);


        var exchangeRateToCreate = _mapper.Map<ExchangeRate>(addExchangeRate);
        await _exchangeRateService.AddAsync(exchangeRateToCreate, ct);
        return CreatedAtAction(nameof(GetExchangeRateById), new { id = exchangeRateToCreate.Id }, new Response<ExchangeRate>(exchangeRateToCreate));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeRatesByCurrencyPair(int from_currencies,int to_currencies,CancellationToken ct) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
    
        Response<List<ExchangeRate>> data = await _exchangeRateService.FindByCondition(e => e.FromCurrency == from_currencies && e.ToCurrency == to_currencies,ct);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeRatesDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(new Response<List<ExchangeRateDto>>(exchangeRatesDto));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatestExchangeRate(int from_currencies, int to_currencies,CancellationToken ct) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        Response<List<ExchangeRate>> data = await _exchangeRateService.FindByCondition(e => e.FromCurrency == from_currencies && e.ToCurrency == to_currencies, ct);
         var orderByDesc =  data.Data.OrderByDescending(e => e.Updated);
        if (orderByDesc is null)
        {
            return NotFound();
        }
        var exchangeRatesDto = _mapper.Map<ExchangeRateDto>(orderByDesc);
        return Ok(new Response<ExchangeRateDto>(exchangeRatesDto));
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteExchangeRate(int id, CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        var exchangeRateResponse = await _exchangeRateService.FindByCondition(x => x.Id == id,ct);
        if (!exchangeRateResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return NotFound();
        }

        var exchangeRate = exchangeRateResponse.Data.FirstOrDefault();

        var data = await _exchangeRateService.DeleteAsync(exchangeRate,ct);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return StatusCode(500, data.Message);
        }
        var exchangeRatesDto = _mapper.Map<bool>(data);
        return Ok(new Response<bool>(data.Data));
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateExchangeRate(int id,ExchangeRate exchangeRate,CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
         exchangeRate.Id = id;

        Response<bool> data = await _exchangeRateService.UpdateAsync(exchangeRate, ct);
        var exchangeRatesDto = _mapper.Map<ExchangeRate>(data);
        return Ok(new Response<ExchangeRate>(exchangeRatesDto));
    }
}
