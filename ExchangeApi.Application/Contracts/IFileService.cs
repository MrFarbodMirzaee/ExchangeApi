﻿using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface IFileService
{
    Task<Response<bool>> UploadFileAsync(ExchangeApi.Domain.Entities.File file, CancellationToken ct);
    Task<DownloadFileDto> DownloadFileAsync(Guid fileId, CancellationToken ct);
}