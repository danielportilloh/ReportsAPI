namespace Reports.API.Map;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Reports.Models.Report, Reports.Data.Models.Report>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<Reports.Data.Models.Report, Reports.Models.Report>();
    }
}