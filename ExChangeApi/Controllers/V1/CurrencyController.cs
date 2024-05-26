using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ExchangeApi.Shered;
using System.Net.Mime;
using ExchangeApi.Domain.Entitiess;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;

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
    public async Task<IActionResult> GetPopularCurrencies()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);


        Response<List<Currency>> data = await _currencyService.GetAllAsync();
        var currencyDto = _mapper.Map<List<CurrencyDto>>(data.Data);
        return Ok(new Response<List<CurrencyDto>>(currencyDto));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActiveCurrencies() 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        Response<List<Currency>> data = await _currencyService.FindByCondition(x => x.IsActive == true);
        if (data is null)
        {
            return NotFound();
        }
        var currencies = _mapper.Map<List<CurrencyDto>>(data);
        return Ok(new Response<List<CurrencyDto>>(currencies));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCurrencyById(int id) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);


        Response<List<Currency>> data = await _currencyService.FindByCondition(x => x.Id == id);
        if (data is null)
        {
            return NotFound();
        }
        var currencyDto = _mapper.Map<CurrencyDto>(data);
        return Ok(new Response<CurrencyDto>(currencyDto));
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCurrencies([FromBody] AddCurencyDto addCurency)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

         var currency = _mapper.Map<Currency>(addCurency);
         await _currencyService.AddAsync(currency);
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
        Response<bool> isValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        Response<List<Currency>> data = await _currencyService.FindByCondition(x => x.CurrencyCode ==  word);
        if (data is null) 
        {
            return NotFound();
        }
        var currencies = _mapper.Map<List<Currency>>(data);
        return Ok(new Response<List<Currency>>(currencies)); // Returning the value of currencyDto
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCurrency(int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);

        // Find the currency by ID
        var currencyResponse = await _currencyService.FindByCondition(x => x.Id == id);
        if (!currencyResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return NotFound();
        }

        // Get the currency object from the response
        var currency = currencyResponse.Data.FirstOrDefault();

        // Delete the currency
        var deleteResponse = await _currencyService.DeleteAsync(currency);
        if (!deleteResponse.Succeeded)
        {
            // Handle the case where the delete operation failed
            return StatusCode(500, deleteResponse.Message);
        }

        // Map the delete response to a boolean DTO
        var CurrenciesDto = _mapper.Map<bool>(deleteResponse.Data);
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
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        // Set the id for the currency based on the route parameter
        currency.Id = id;

        var updatedCurrency = await _currencyService.UpdateAsync(currency);
   
        var updatedCurrencyDto = _mapper.Map<Currency>(updatedCurrency); // Assuming CurrencyDto is the DTO for Currency

        return Ok(updatedCurrencyDto);
    }
}
