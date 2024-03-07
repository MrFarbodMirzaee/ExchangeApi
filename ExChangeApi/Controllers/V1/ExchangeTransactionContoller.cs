using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class ExchangeTransactionContoller : BaseContoller
{
    private readonly IExchangeTransactionBusiness _exchangeTranzacstionBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    public ExchangeTransactionContoller(IExchangeTransactionBusiness exchangeTranzacstionBusiness,IMapper mapper,IOptionsMonitor<MySettings> settings)
    {
        _settings = settings.CurrentValue;
        _exchangeTranzacstionBusiness = exchangeTranzacstionBusiness;
        _mapper = mapper;
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
       var exchangeTransaction = _mapper.Map<ExchangeTransactionDto>(data);
        return Ok(exchangeTransaction);
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
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddExchangeTransaction([FromBody] ExchangeTransactionDto addExchangeTransaction)
    {
        if (addExchangeTransaction.FromCurrencyId < 0 || addExchangeTransaction.ToCurrencyId < 0 )
        {
            return BadRequest();
        }
        var exchangetransaction = _mapper.Map<ExchangeTransaction>(addExchangeTransaction);
        _exchangeTranzacstionBusiness.CreateExchangeTransaction(exchangetransaction);
        return Created();
    }
}
