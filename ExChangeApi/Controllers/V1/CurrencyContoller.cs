using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ExchangeApi.Shered;
using ExchangeApi.Dtos;
using System.Net.Mime;
using ExchangeApi.Domain.Entitiess;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.Contracts;

namespace ExchangeApi.Controllers.V1;

public class CurrencyContoller : BaseContoller
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public CurrencyContoller(ICurrencyService currencyService, IMapper mapper,IOptionsMonitor<MySettings> settings, IIpAddresssValdatorServices ipAddresssValdatorClass)
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
    public async Task<IActionResult> GetPopularCurrencies()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress) 
        {
            return BadRequest();
        }

        var data = await _currencyService.GetPopularCurrencies();
        var currencyDto = _mapper.Map<List<Currency>>(data);
        return Ok(currencyDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActiveCurrencies() 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _currencyService.GetAllActiveCurrencies();
        var currenciesDto = _mapper.Map<List<Currency>>(data);
        return Ok(currenciesDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCurrencyById(int id) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _currencyService.GetCurrencyById(id);
        var currenciesDto = _mapper.Map<Currency>(data);
        return Ok(currenciesDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCurrencies([FromBody] AddCurencyDto addCurency)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var currency = _mapper.Map<Currency>(addCurency);
        await _currencyService.CreateCurrency(currency);
         return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchCurrency(string word)
    {
        var clientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(clientIpAddress);

        // Assuming that ValidatorIpAddress returns a boolean indicating the validity of the IP address
        bool isValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        if (!isValidAddress)
        {
            return BadRequest("Invalid IP Address");
        }

        var data = await _currencyService.SearchCurrencies(word);
        var currencyDto = _mapper.Map<List<Currency>>(data);

        return Ok(currencyDto); // Returning the value of currencyDto
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCurrency(int id) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }
        var data = await _currencyService.DeleteCurrency(id);
        var CurrenciesDto = _mapper.Map<bool>(data);
        return Ok(CurrenciesDto);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCurrency(int id, Currency currency)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        // Set the id for the currency based on the route parameter
        currency.Id = id;

        var updatedCurrency = await _currencyService.UpdateCurrency(currency);
        var updatedCurrencyDto = _mapper.Map<Currency>(updatedCurrency); // Assuming CurrencyDto is the DTO for Currency

        return Ok(updatedCurrencyDto);
    }
}
