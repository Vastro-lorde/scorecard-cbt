using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using System;
using System.Threading.Tasks;

namespace scorecard_cbt.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IResultServices _resultServices;

        public ExamResultController(IResultServices resultServices)
        {
            _resultServices = resultServices;
        }

        [HttpGet("GetExamResultById/{id}")]
        public async Task<IActionResult> GetPerformanceById(string id)
        {
            try
            {
                return Ok(await _resultServices.GetResultByIdAsync(id));
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


        [HttpGet("GetAllExamResults")]
        public async Task<IActionResult> GetAllPerformanceScore(int pageSize, int pageNumber)
        {
            try
            {
                return Ok(await _resultServices.GetAllResultsAsync(pageSize,pageNumber));
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


        [HttpGet("GetAllExamResultByUserId")]
        public async Task<IActionResult> GetAllExamResultByUserId(int pageSize, int pageNumber, string UserId)
        {
            try
            {
                return Ok(await _resultServices.GetResultsByUserIdAsync(pageSize, pageNumber, UserId));
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


        [HttpGet("GetAllExamResultByExam/{id}")]
        public async Task<IActionResult> GetAllExamResultByExam(string id, int pageSize, int pageNumber)
        {
            try
            {
                return Ok(await _resultServices.GetResultsByExamAsync(pageSize, pageNumber, id));
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


        [HttpPost("CreateExamResult")]
        public async Task<IActionResult> CreateExamResult(CreateResultDto createResult)
        {
            try
            {
                return Ok(await _resultServices.CreateResultAsync(createResult));
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


        [HttpDelete("DeleteExamResult/{id}")]
        public async Task<IActionResult> DeleteExamResultById(string Id)
        {
            try
            {
                return Ok(await _resultServices.DeleteResultAsync(Id));
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
    }
}
