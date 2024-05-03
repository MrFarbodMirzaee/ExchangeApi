using ExchangeApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Application.Contracts;

public interface IAutenticationService
{
    Task<AuthenticationResponseDto> Login(LoginDto dto);
    Task<AuthenticationResponseDto> Register(RegisterDto dto);
}
