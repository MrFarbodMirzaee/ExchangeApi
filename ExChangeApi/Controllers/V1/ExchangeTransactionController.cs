﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;

namespace ExchangeApi.Controllers.V1;

public class ExchangeTransactionController : BaseController
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    private readonly MySettings _settings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public ExchangeTransactionController(IExchangeTransactionServices exchangeTranzacstionService,IMapper mapper,IOptionsMonitor<MySettings> settings, IIpAddresssValdatorServices ipAddresssValdatorClass)
    {
        _settings = settings.CurrentValue;
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
        _ipAddresssValdatorClass = ipAddresssValdatorClass;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExchangeTransactionById([FromRoute] int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeTranzacstionService.GetExchangeTransactionById(id);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeTransaction = _mapper.Map<ExchangeTransactionDto>(data);
        return Ok(exchangeTransaction);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExchangeTransactions()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeTranzacstionService.GetAllExchangeTransactions();
        var ExchangeTranzactionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(ExchangeTranzactionDto);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddExchangeTransaction(AddExchangeTransactionDto addExchangeTransaction)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var exchangetransaction = _mapper.Map<ExchangeTransaction>(addExchangeTransaction);
        await _exchangeTranzacstionService.CreateExchangeTransaction(exchangetransaction);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsByCurrencyPair(int from_currencies,int to_currencies) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeTranzacstionService.GetTransactionsByCurrencyPair(from_currencies,to_currencies);
        if (data is null) 
        {
            return NotFound(); 
        }
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(exchangeTranzacstionDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsById(int userid) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeTranzacstionService.GetTransactionsByUserId(userid);
        if (data is null) 
        {
            return NotFound();
        }
        var exchangeTranzacstionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return Ok(exchangeTranzacstionDto);
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTransactions(int userid)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = await _exchangeTranzacstionService.DeleteExchangeTransaction(userid);
        var exchangeTranzacstionDto = _mapper.Map<bool>(data);
        return Ok(exchangeTranzacstionDto);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTransactions(int id ,ExchangeTransaction exchangeTransaction)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        exchangeTransaction.Id = id;

        var data = await _exchangeTranzacstionService.UpdateExchangeTransaction(exchangeTransaction);
        var exchangeTranzacstionDto = _mapper.Map<ExchangeTransaction>(data);
        return Ok(exchangeTranzacstionDto);
    }
}