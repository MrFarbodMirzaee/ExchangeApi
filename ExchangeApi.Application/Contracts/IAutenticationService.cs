using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Application.Contracts;

public interface IAutenticationService
{
    Task<Response<AuthenticationResponseDto>> Login(LoginDto dto, CancellationToken ct);
    Task<Response<AuthenticationResponseDto>> Register(RegisterDto dto, CancellationToken ct);
}
