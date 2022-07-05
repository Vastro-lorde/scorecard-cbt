using AutoMapper;
using scorecard_cbt.Models;

namespace scorecard_cbt.DTOs.Mapping
{
    public class CBTMappings : Profile
    {
        public CBTMappings()
        {
            CreateMap<Course, CourseResponseDto>().ReverseMap();
            CreateMap<CourseRegistrationDto, Course>().ReverseMap();
            CreateMap<Course, GetAllCourseResponseDto>().ReverseMap();
            CreateMap<CourseDetailResponseDto, Course>().ReverseMap();

            CreateMap<Exam, ExamResponseDto>().ReverseMap();
            CreateMap<ExamRegistrationDto, Exam>().ReverseMap();
            CreateMap<ExamDetailResponseDto, Exam>().ReverseMap();
        }
    }
}
