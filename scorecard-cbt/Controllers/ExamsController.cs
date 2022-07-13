using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using System;
using System.Threading.Tasks;

namespace scorecard_cbt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExam(ExamRegistrationDto registrationRequest)
        {
            return Ok(await _examService.RegisterExamAsync(registrationRequest));
        }

        [HttpGet("GetExamById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await _examService.GetExamByIdAsync(id));
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

        [HttpDelete("DeleteExam")]
        public async Task<IActionResult> DeleteExam(string courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedExam = await _examService.DeleteExamAsync(courseId);
            return StatusCode((int)deletedExam.ResponseCode, deletedExam);
        }

        [HttpGet("GetAllExams")]
        public async Task<IActionResult> GetAllExams(int pageSize, int pageNumber)
        {
            var response = await _examService.GetAllExamAsync(pageSize, pageNumber);
            return StatusCode((int)response.ResponseCode, response);
        }
    }
}
