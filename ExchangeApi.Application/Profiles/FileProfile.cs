using AutoMapper;
using ExchangeApi.Application.UseCases.File.Upload;

namespace ExchangeApi.Application.Profiles;
public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<UploadFileCommand, ExchangeApi.Domain.Entities.File>()
             .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
             .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.File.ContentType))
             .ForMember(dest => dest.FileData, opt => opt.Ignore())
             .AfterMap(async (src, dest) =>
             {
                 using var memoryStream = new MemoryStream();
                 await src.File.CopyToAsync(memoryStream);
                 dest.FileData = memoryStream.ToArray();
             });
    }
}
