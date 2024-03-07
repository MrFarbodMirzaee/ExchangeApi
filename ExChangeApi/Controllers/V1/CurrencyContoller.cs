using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ExchangeApi.Contract;
using ExchangeApi.Shered;
using ExchangeApi.Dtos;
using ExChangeApi.Models;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class CurrencyContoller : BaseContoller
{
    private readonly ICurrencyBusiness _currencyBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    public CurrencyContoller(ICurrencyBusiness currencyBusiness, IMapper mapper,IOptionsMonitor<MySettings> settings)
    {
        _settings = settings.CurrentValue;
        _currencyBusiness = currencyBusiness;
        _mapper = mapper;
    }


    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var data = _currencyBusiness.GetCurrencyById(id);
        if (data is null)
        {
            return NotFound();
        }
        var currencyDto = _mapper.Map<CurrencyDto>(data);
        return Ok(currencyDto);
    }
    [HttpGet]
    public Currency GetCurrency()
    {
        return new Currency()
        {
            Id = 1,
            Name = "Euro",
            Created = DateTime.Now,
            CurrencyCode = "EUR"
        };
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddCurrencies([FromBody] AddCurencyDto addCurency)
    {
        if (string.IsNullOrEmpty(addCurency.Name) || string.IsNullOrEmpty(addCurency.CurrencyCode)) 
        {
            return BadRequest();
        }
        var currency = _mapper.Map<Currency>(addCurency);
        _currencyBusiness.CreateCurrency(currency);
         return Created();
    }
}
