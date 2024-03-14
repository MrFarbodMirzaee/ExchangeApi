using AutoMapper;
using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExchangeApi.Models;
using ExchangeApi.Shered;
using ExChangeApi.Business;
using ExChangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class ExchangeRateContoller : BaseContoller
{
    private readonly IExchangeRateBusiness _exchangeRateBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    public ExchangeRateContoller(IExchangeRateBusiness exchangeRateBusiness,IMapper mapper,IOptionsMonitor<MySettings> settings)
    {
        _settings = settings.CurrentValue;
        _exchangeRateBusiness = exchangeRateBusiness;
        _mapper = mapper;
    }


    [Route("{id}")]
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<IActionResult> GetExchangeRateById([FromRoute] int id)
    {
        var data = _exchangeRateBusiness.GetExchangeRateById(id);
        var exchangeRateDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(exchangeRateDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeRates()
    {
        var data = _exchangeRateBusiness.GetAllExchangeRates();
        var exchangeRateDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(exchangeRateDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddExchangeRate([FromBody] AddExchangeRateDto addExchangeRate)
    {
        var exchangeRate = _mapper.Map<ExchangeRate>(addExchangeRate);
        _exchangeRateBusiness.CreateExchangeRate(exchangeRate);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeRatesByCurrencyPair(int from_currencies,int to_currencies) 
    {
        var data = _exchangeRateBusiness.GetExchangeRatesByCurrencyPair(from_currencies,to_currencies);
        var exchangeRatesDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return Ok(exchangeRatesDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatestExchangeRate(int from_currencies, int to_currencies) 
    {
        var data = _exchangeRateBusiness.GetLatestExchangeRate(from_currencies,to_currencies);
        var exchangeRatesDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(exchangeRatesDto);
    }

}
