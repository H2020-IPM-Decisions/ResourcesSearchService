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
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.DssModelInformation.Name))
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => src.DssModelInformation.ValidSpatial.Countries))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.DssInformation.Languages));

            CreateMap<DssInformationJoined, SearchDetailedResponseDto>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => string.Format("{0};{1}", src.DssInformation.Id, src.DssModelInformation.Id)))
                .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.DssModelInformation.Name))
                .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => src.DssModelInformation.ValidSpatial.Countries))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.DssInformation.Languages))
                .ForMember(dest => dest.Crops, opt => opt.MapFrom(src => src.DssModelInformation.Crops))
                .ForMember(dest => dest.Pests, opt => opt.MapFrom(src => src.DssModelInformation.Pests))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.DssInformation.DssOrganization.Email))
                .ForMember(dest => dest.ContactInstitution, opt => opt.MapFrom(src => src.DssInformation.DssOrganization.Name))
                .ForMember(dest => dest.ContactAddress, opt => opt.MapFrom(src => string.Format("{0}, {1}, {2}, {3}",
                    src.DssInformation.DssOrganization.Address, src.DssInformation.DssOrganization.City, src.DssInformation.DssOrganization.Country, src.DssInformation.DssOrganization.PostalCode)))
                .ForMember(dest => dest.Citation, opt => opt.MapFrom(src => src.DssModelInformation.Citation))
                .ForMember(dest => dest.ResourceOrigin, opt => opt.MapFrom(src => src.DssModelInformation.DescriptionUrl))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.DssModelInformation.Description));
        }
    }
}