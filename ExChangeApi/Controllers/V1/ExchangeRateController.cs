using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Shered;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class ExchangeRateController : BaseContoller
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
    public async Task<IActionResult> GetExchangeRateById([FromRoute] int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }
        var data = await _exchangeRateService.GetExchangeRateById(id);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeRateDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(exchangeRateDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeRates()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeRateService.GetAllExchangeRates();
        var exchangeRateDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(exchangeRateDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddExchangeRate([FromBody] AddExchangeRateDto addExchangeRate)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var exchangeRate = _mapper.Map<ExchangeRate>(addExchangeRate);
       await _exchangeRateService.CreateExchangeRate(exchangeRate);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeRatesByCurrencyPair(int from_currencies,int to_currencies) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeRateService.GetExchangeRatesByCurrencyPair(from_currencies,to_currencies);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeRatesDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(exchangeRatesDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatestExchangeRate(int from_currencies, int to_currencies) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeRateService.GetLatestExchangeRate(from_currencies,to_currencies);
        if (data is null)
        {
            return NotFound();
        }
        var exchangeRatesDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(exchangeRatesDto);
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteExchangeRate(int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeRateService.DeleteExchangeRate(id);
        var exchangeRatesDto = _mapper.Map<bool>(data);
        return Ok(exchangeRatesDto);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateExchangeRate(int id,ExchangeRate exchangeRate)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        exchangeRate.Id = id;

        var data = await _exchangeRateService.UpdateExchangeRate(exchangeRate);
        var exchangeRatesDto = _mapper.Map<ExchangeRate>(data);
        return Ok(exchangeRatesDto);
    }
}
