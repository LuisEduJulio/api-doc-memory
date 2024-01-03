using api_doc_memory.domain.Dtos;
using api_doc_memory.domain.Entities;
using api_doc_memory.domain.ModelViews;
using AutoMapper;

namespace api_doc_memory.application.Mapper
{
    public class MapperPersonProfile : Profile
    {
        public MapperPersonProfile()
        {
            CreateMap<PersonAddDto, PersonEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<PersonUpdateDto, PersonEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<PersonFilterDto, PersonEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PersonEntity, PersonGetModelView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));

            CreateMap<PersonEntity, PersonUpdateModelView>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        }
    }
}