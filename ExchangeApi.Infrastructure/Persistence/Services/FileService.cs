﻿using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using ResourceApi.Messages;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class FileService(AppDbContext applicationDbContext, IMapper mapper)
    : GenericRepository<ExchangeApi.Domain.Entities.File>(applicationDbContext), IFileService
{
    private readonly AppDbContext _applicationDbContext = applicationDbContext;

    public async Task<DownloadFileDto> DownloadFileAsync(Guid fileId, CancellationToken ct)
    {
        var fileEntity = await _applicationDbContext.File
            .Where(f => f.Id == fileId)
            .FirstOrDefaultAsync(ct); 

        if (fileEntity == null)
        {
            throw new 
                FileNotFoundException
                (Validations.NoData,fileId.ToString());
        }

        var fileDto = mapper
            .Map<DownloadFileDto>
            (fileEntity);

        return fileDto;
    }

    public async Task<Response<bool>> UploadFileAsync(ExchangeApi.Domain.Entities.File file, CancellationToken ct)
    {
        await _applicationDbContext
            .File
            .AddAsync(file, ct);

        var rowsAffected = await _applicationDbContext
            .SaveChangesAsync(ct);

        if (rowsAffected == 0)
            return new 
                Response<bool>
                (Validations.NotUploaded);

        return new 
            Response<bool>
            (true);
    }
}

