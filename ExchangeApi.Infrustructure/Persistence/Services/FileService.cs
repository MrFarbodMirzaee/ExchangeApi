﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrustructure.Persistence.Services;
public class FileService : GenericRepository<ExchangeApi.Domain.Entities.File>, IFileService
{
    private readonly AppDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public FileService(AppDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<DownloadFileDto> DownloadFileAsync(int fileId, CancellationToken ct)
    {
        var fileEntity = await _applicationDbContext.File
        .Where(f => f.Id == fileId) // It's better to use LINQ's .Where for clarity
        .FirstOrDefaultAsync(ct);    // This will return null if not found

        if (fileEntity == null)
        {
            throw new FileNotFoundException($"File not found with ID: {fileId}");
        }

        // Map the file entity to a DownloadFileDto
        var fileDto = _mapper.Map<DownloadFileDto>(fileEntity);

        return fileDto;
    }

    public async Task<Response<bool>> UploadFileAsync(ExchangeApi.Domain.Entities.File file, CancellationToken ct)
    {
        try
        {
            await _applicationDbContext.File.AddAsync(file);

            // Save changes to persist the file in the database
            var rowsAffected = await _applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>("File didn't upload");

            return new Response<bool>(true);
        }
        catch (DbUpdateException ex)
        {
            return new Response<bool>($"Add failed due to a database update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new Response<bool>($"Add failed: {ex.Message}");
        }
    }
}
