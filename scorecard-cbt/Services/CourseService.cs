using AutoMapper;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories;
using scorecard_cbt.Repositories.Interfaces;
using scorecard_cbt.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace scorecard_cbt.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Response<CourseDetailResponseDto>> GetCourseByIdAsync(string courseId)
        {
            Course course = await _courseRepository.GetCourseByIdAsync(courseId);

            if (course != null)
            {
                var result = _mapper.Map<CourseDetailResponseDto>(course);
                return new Response<CourseDetailResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            throw new ArgumentException("Resourse not found");

        }
        public async Task<CourseResponseDto> RegisterCourseAsync(CourseRegistrationDto registrationRequest)
        {
            Course course = _mapper.Map<Course>(registrationRequest);
            await _courseRepository.CreateCourseAsync(course); 
            var answer = new CourseResponseDto
            {
                Title = course.Title,
                ImageUrl = course.ImageUrl,
                Code = course.Code
            };

            return answer;
        }
        public async Task<Response<Course>> DeleteCourseAsync(string courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return new Response<Course>()
                {
                    Message = "Course Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            await _courseRepository.Delete(course);
            
            return new Response<Course>()
            {
                Message = "Course Successfully Deleted",
                ResponseCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
        }
        public async Task<Response<PaginationModel<IEnumerable<GetAllCourseResponseDto>>>> GetAllCoursesAsync(int pageSize, int pageNumber)
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            var response = _mapper.Map<IEnumerable<GetAllCourseResponseDto>>(courses);

            if (courses != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<GetAllCourseResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Courses",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<GetAllCourseResponseDto>>>()
            {
                Data = null,
                Message = "No Registered Courses",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }
        public async Task<Response<string>> UpdateCourseDetails(string Id, UpdateCourseDto updateCourseDto)
        {
            var course = await _courseRepository.GetCourseByIdAsync(Id);

            if (course != null)
            {
                course.Title = updateCourseDto.Title;
                course.Description = updateCourseDto.Description;
                course.Overview = updateCourseDto.Overview;
                course.Code = updateCourseDto.Code;
                var result = await _courseRepository.UpdateCourseAsync(course);

                if (result)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Course updated",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    Message = "Course not updated",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            throw new ArgumentException("Course not found");
        }
    }
}
