using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class CurrencyAttributeController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ICurrencyAttributeService _currencyService;
    public CurrencyAttributeController(IMapper mapper, ICurrencyAttributeService currencyService) 
    {
        _mapper = mapper;
        _currencyService = currencyService;
    }
    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCurrencies([FromBody] AddCurrencyAttributeDto dto)
    {
        var currencyattribute = _mapper.Map<CurrencyAttribute>(dto);
        await _currencyService.CreateCurrencyAttribute(currencyattribute);
        return Created();
    }
}
