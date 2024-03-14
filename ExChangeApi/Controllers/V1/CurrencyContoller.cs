﻿using AutoMapper;
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
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<IActionResult> GetPopularCurrencies()
    {
        var data = _currencyBusiness.GetPopularCurrencies();
        var currencyDto = _mapper.Map<List<Currency>>(data);
        return Ok(currencyDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActiveCurrencies() 
    {
        var data = _currencyBusiness.GetAllActiveCurrencies();
        var currenciesDto = _mapper.Map<List<Currency>>(data);
        return Ok(currenciesDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCurrenciesById(int id) 
    {
        var data = _currencyBusiness.GetCurrencyById(id);
        var currenciesDto = _mapper.Map<Currency>(data);
        return Ok(currenciesDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddCurrencies([FromBody] AddCurencyDto addCurency)
    { 
        var currency = _mapper.Map<Currency>(addCurency);
        _currencyBusiness.CreateCurrency(currency);
         return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchCurrencies(string word) 
    {
        var data = _currencyBusiness.SearchCurrencies(word);
        var currencyDto = _mapper.Map<List<Currency>>(data);
        return Ok(currencyDto);
    }

}
