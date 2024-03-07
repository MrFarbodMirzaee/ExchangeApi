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
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var data = _exchangeRateBusiness.GetExchangeRateById(id);
        if (data == null)
        {
            return NotFound();
        }
        var exchangeRateDto = _mapper.Map<ExchangeRateDto>(data);
        return Ok(exchangeRateDto);
    }
    [HttpGet]
    public ExchangeRate GetExChangeRate()
    {
        return new ExchangeRate()
        {
            Id = 1,
            FromCurrency = 1,
            ToCurrency = 3,
            Rate = 25.03m,
            IsActive = true,
            Created = DateTime.Now,
            LastUpdate = DateTime.Now,
        };
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddExchangeRate([FromBody] AddExchangeRateDto addExchangeRate)
    {
        if (addExchangeRate.FromCurrency < 0 || addExchangeRate.ToCurrency < 0 || addExchangeRate.Rate < 0)
        {
            return BadRequest();
        }
        var exchangeRate = _mapper.Map<ExchangeRate>(addExchangeRate);
        _exchangeRateBusiness.CreateExchangeRate(exchangeRate);
        return Created();
    }
}
