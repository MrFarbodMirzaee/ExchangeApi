﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
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

