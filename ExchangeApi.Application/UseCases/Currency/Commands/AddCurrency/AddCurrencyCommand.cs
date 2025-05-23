﻿#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;

public record AddCurrencyCommand : IRequest<Response<bool>>
{
    public string CurrencyCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public Guid CategoryId { get; set; }
    public string ImagePath { get; set; }
    public bool IsActive { get; set; }
}