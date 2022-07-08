﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using System;
using System.Threading.Tasks;

namespace scorecard_cbt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("GetQuestionById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await _questionService.GetQuestionByIdAsync(id));
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

        [HttpGet("GetQuestions")]
        public async Task<IActionResult> GetAllQuestions(int pageSize, int pageNumber)
        {
            try
            {
                return Ok(await _questionService.GetAllQuestionsAsync(pageSize, pageNumber));
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

        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(QuestionRequestDto createQuestion)
        {
            try
            {
                return Ok(await _questionService.CreateQuestionAsync(createQuestion));
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

        [HttpDelete("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(string QuestionId)
        {
            try
            {
                return Ok(await _questionService.DeleteQuestionAsync(QuestionId));
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

        [HttpGet("UpdateQuestion/{id}")]
        public async Task<IActionResult> UpdateQuestionById(string QuestionId, UpdateQuestionDto updateQuestion)
        {
            try
            {
                return Ok(await _questionService.UpdateQuestionDetails(QuestionId, updateQuestion));
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