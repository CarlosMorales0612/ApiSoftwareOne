using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class MyEntityDto
    {
        public string? TitleTask { get; set; }
        public string? DescriptionTask { get; set; }
        public DateTime CreationTask { get; set; }
        public bool CompletedTask { get; set; }


        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<TaskEntity, MyEntityDto>()
                    .ForMember(dest => dest.TitleTask, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.DescriptionTask, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.CreationTask, opt => opt.MapFrom(src => src.Creation))
                    .ForMember(dest => dest.CompletedTask, opt => opt.MapFrom(src => src.Completed))
                    .ReverseMap();
            }
        }
        //
    }
}