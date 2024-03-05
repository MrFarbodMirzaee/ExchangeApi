using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExChangeApi.Dtos;
using ExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers.V1;

public class ExchangeTransactionContoller : BaseContoller
{
    private readonly IExchangeTransactionBusiness _exchangeTranzacstionBusiness;
    public ExchangeTransactionContoller(IExchangeTransactionBusiness exchangeTranzacstionBusiness)
    {
        _exchangeTranzacstionBusiness = exchangeTranzacstionBusiness;
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var data = _exchangeTranzacstionBusiness.GetExchangeTransactionById(id);
        if (data == null)
        {
            return NotFound();
        }
        ExchangeTransactionDto exchangeTRansaction = new ExchangeTransactionDto()
        {
            Id = data.Id,
            Amount = data.Amount,
            ExchangeRateId = data.ExChangeRateId,
            FromCurrencyId = data.FromCurrencyId,
            ToCurrencyId = data.ToCurrencyId,
            ResultAmount = data.ResultAmount
        };
        return Ok(exchangeTRansaction);
    }
    [HttpGet]
    public ExchangeTransaction GetExChangeTransaction()
    {
        return new ExchangeTransaction()
        {
            Id = 1,
            Amount = 30.00m,
            ResultAmount = 70.00m,
            ExChangeRateId = 4,
            FromCurrencyId = 3,
            ToCurrencyId = 2,
            TransactionDate = DateTime.Now,
            IsActive = true,
            Created = DateTime.Now
        };
    }
    public IActionResult AddExchangeTransaction([FromBody] AddExchangeTransaction addExchangeTransaction)
    {
        if (addExchangeTransaction.FromCurrencyId < 0 || addExchangeTransaction.ToCurrencyId < 0 )
        {
            return BadRequest();
        }
        var ExchangeTransactiondata = new ExchangeTransaction()
        {
            Id = 1,
            Created = DateTime.Now,
        };
        _exchangeTranzacstionBusiness.CreateExchangeTransaction(ExchangeTransactiondata);
        return Created();
    }
}
