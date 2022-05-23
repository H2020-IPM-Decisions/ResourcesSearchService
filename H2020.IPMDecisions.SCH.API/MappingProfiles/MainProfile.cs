using AutoMapper;
using H2020.IPMDecisions.SCH.API.Dtos;
using H2020.IPMDecisions.SCH.API.Models;

namespace H2020.IPMDecisions.SCH.API.MappingProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<string, string>()
                .ConvertUsing(str => (str ?? "").Trim());

            CreateMap<DssModelInformation, SearchResponseDto>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.Name));

            CreateMap<DssInformationJoined, SearchResponseDto>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => string.Format("{0};{1}", src.DssInformation.Id, src.DssModelInformation.Id)))
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.DssModelInformation.Name));
        }
    }
}