using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories;
using scorecard_cbt.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace scorecard_cbt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IImageService _imageService;
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseService courseService, ICourseRepository courseRepository, IImageService imageService)
        {
            _courseService = courseService;
            _imageService = imageService;
            _courseRepository = courseRepository;
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse(CourseRegistrationDto registrationRequest)
        {
            return Ok(await _courseService.RegisterCourseAsync(registrationRequest));
        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses(int pageSize, int pageNumber)
        {
            var response = await _courseService.GetAllCoursesAsync(pageSize, pageNumber);
            return StatusCode((int)response.ResponseCode, response);
        }


        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await _courseService.GetCourseByIdAsync(id));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPut("UpdateCourse")]
        public async Task<IActionResult> UpdateUser(string Id, UpdateCourseDto updateCoursedDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    var result = await _courseService.UpdateCourseDetails(Id, updateCoursedDto);
                    return Ok(result);
                }
                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Try again after 5 minutes");
            }
        }


        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> DeleteACourse(string courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedCourse = await _courseService.DeleteCourseAsync(courseId);
            return StatusCode((int)deletedCourse.ResponseCode, deletedCourse);
        }


        [HttpPatch("Id/UploadImage")]
        public async Task<IActionResult> UploadImage(string Id, [FromForm] AddImageDto imageDto)
        {
            try
            {
                var course = await _courseRepository.GetCourseByIdAsync(Id);

                if (course != null)
                {
                    var upload = await _imageService.UploadAsync(imageDto.Image);
                    var result = new ImageAddedDto()
                    {
                        PublicId = upload.PublicId,
                        Url = upload.Url.ToString()
                    };

                    course.ImageUrl = result.Url;
                    course.PublicId = result.PublicId;
                    await _courseRepository.UpdateCourseAsync(course);
                    return Ok(result);
                }
                return NotFound("Course not found");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
