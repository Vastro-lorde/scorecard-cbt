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
    public class OptionsController : ControllerBase
    {
        private readonly IOptionService _optionService;
        public OptionsController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpGet("GetOptionById/{id}")]
        public async Task<IActionResult> GetOptionById(string id)
        {
            try
            {
                return Ok(await _optionService.GetOptionByIdAsync(id));
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

        [HttpGet("GetAllOptions")]
        public async Task<IActionResult> GetAllOptions(int pageSize, int pageNumber)
        {
            try
            {
                return Ok(await _optionService.GetAllOptionsAsync(pageSize, pageNumber));
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

        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption(string QuestionId, OptionRequestDto createOption)
        {
            try
            {
                return Ok(await _optionService.CreateOptionAsync(QuestionId, createOption));
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

        [HttpDelete("DeleteOption")]
        public async Task<IActionResult> DeleteOption(string OptionId)
        {
            try
            {
                return Ok(await _optionService.DeleteOptionAsync(OptionId));
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
        [HttpPut("UpdateOption")]
        public async Task<IActionResult> UpdateOptionById(string OptionId, UpdateOptionDto updateOptionDto)
        {
            try
            {
                return Ok(await _optionService.UpdateOptionDetails(OptionId, updateOptionDto));
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
        [HttpGet("GetOptionByQuestion")]
        public async Task<IActionResult> GetOptionsByQuestionAsync(string QuestionId)
        {
            try
            {
                return Ok(await _optionService.GetOptionsByQuestionAsync(QuestionId));
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
