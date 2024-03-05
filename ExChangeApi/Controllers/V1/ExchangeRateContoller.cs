using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExchangeApi.Models;
using ExChangeApi.Business;
using ExChangeApi.Dtos;
using ExChangeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers.V1;

public class ExchangeRateContoller : BaseContoller
{
    private readonly IExchangeRateBusiness _exchangeRateBusiness;
    public ExchangeRateContoller(IExchangeRateBusiness exchangeRateBusiness)
    {
        _exchangeRateBusiness = exchangeRateBusiness;
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
        ExchangeRateDto exchangeRate = new ExchangeRateDto()
        {
            Id = data.Id,
            FromCurrency = data.FromCurrency,
            LastUpdate = data.LastUpdate,
            ToCurrency = data.ToCurrency,
            Rate = data.Rate,
        };
        return Ok(exchangeRate);
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
    public IActionResult AddExchangeRate([FromBody] AddExchangeRate addExchangeRate)
    {
        if (addExchangeRate.FromCurrency < 0 || addExchangeRate.ToCurrency < 0 || addExchangeRate.Rate < 0)
        {
            return BadRequest();
        }
        var ExchangeRatedata = new ExchangeRate()
        {
            Id = 1,
            FromCurrency = addExchangeRate.FromCurrency,
            ToCurrency = addExchangeRate.ToCurrency,
            Rate = addExchangeRate.Rate,
            Created = DateTime.Now,
        };
        _exchangeRateBusiness.CreateExchangeRate(ExchangeRatedata);
        return Created();
    }
}
