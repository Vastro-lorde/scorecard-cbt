using AutoMapper;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using scorecard_cbt.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace scorecard_cbt.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IOptionRepository optionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionDetailResponseDto>> GetQuestionByIdAsync(string QuestionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(QuestionId);
            question.Options = await _optionRepository.GetOptionByQuestionAsync(QuestionId);
            if (question != null)
            {
                var result = _mapper.Map<QuestionDetailResponseDto>(question);
                return new Response<QuestionDetailResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Question>> CreateQuestionAsync(QuestionRequestDto createQuestion)
        {
            Question question = _mapper.Map<Question>(createQuestion);
            var result = await _questionRepository.CreateQuestionAsync(question);
            if (result)
            {
                return new Response<Question>()
                {
                    Data = question,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Question>> DeleteQuestionAsync(string QuestionId)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(QuestionId);
            if (question == null)
            {
                return new Response<Question>()
                {
                    Message = "Question Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            await _questionRepository.DeleteQuestion(question);

            return new Response<Question>()
            {
                Message = "Question Successfully Deleted",
                ResponseCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
        }

        public async Task<Response<string>> UpdateQuestionDetails(string QuestionId, UpdateQuestionDto updateQuestionDto)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(QuestionId);

            if (question != null)
            {
                question.AnswerOption = updateQuestionDto.AnswerOption;
                question.Status = updateQuestionDto.Status;
                question.Description = updateQuestionDto.Description;
                question.UpdatedBy = updateQuestionDto.UpdatedBy;
                var result = await _questionRepository.UpdateQuestionAsync(question);

                if (result)
                {
                    return new Response<string>()
                    {
                        IsSuccessful = true,
                        Message = "Question updated",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<string>()
                {
                    IsSuccessful = false,
                    Message = "Question not updated",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            throw new ArgumentException("Question not found");
        }

        public async Task<Response<PaginationModel<IEnumerable<GetAllQuestionResponseDto>>>> GetAllQuestionsAsync(int pageSize, int pageNumber)
        {
            var questions = await _questionRepository.GetAllQuestionsAsync();
            var response = _mapper.Map<IEnumerable<GetAllQuestionResponseDto>>(questions);

            if (questions != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<GetAllQuestionResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Questions",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<GetAllQuestionResponseDto>>>()
            {
                Data = null,
                Message = "No Questions Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }
    }
}
