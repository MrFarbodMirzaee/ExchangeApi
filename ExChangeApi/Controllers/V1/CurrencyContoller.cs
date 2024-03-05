using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExChangeApi.Business;
using ExChangeApi.Dtos;
using ExChangeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers.V1;

public class CurrencyContoller : BaseContoller
{
    private readonly ICurrencyBusiness _currencyBusiness;
    public CurrencyContoller(ICurrencyBusiness currencyBusiness)
    {
        _currencyBusiness = currencyBusiness;
    }


    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var data = _currencyBusiness.GetCurrencyById(id);
        if (data == null)
        {
            return NotFound();
        }
        CurrencyDto currencyDto = new CurrencyDto()
        {
            Id = data.Id,
            CurrencyCode = data.CurrencyCode,
            Name = data.Name,
        };
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
    public IActionResult AddCurrencies([FromBody] AddCurency addCurency)
    {
        if (string.IsNullOrEmpty(addCurency.Name) || string.IsNullOrEmpty(addCurency.CurrencyCode)) 
        {
            return BadRequest();
        }
        var Currecydata = new Currency() 
        {
            Id = 1,
            Created = DateTime.Now,
            CurrencyCode = addCurency.CurrencyCode,
            Name = addCurency.Name,
        };
        _currencyBusiness.CreateCurrency(Currecydata);
         return Created();
    }
}
