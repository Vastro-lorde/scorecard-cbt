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
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        public OptionService(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<Response<OptionDetailResponseDto>> GetOptionByIdAsync(string OptionId)
        {
            var option = await _optionRepository.GetOptionByIdAsync(OptionId);
            if (option != null)
            {
                var result = _mapper.Map<OptionDetailResponseDto>(option);
                return new Response<OptionDetailResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Option>> CreateOptionAsync(string QuestionId, OptionRequestDto createOption)
        {
            Option option = _mapper.Map<Option>(createOption);

            var result = await _optionRepository.CreateOptionAsync(QuestionId, option);
            if (result)
            {
                return new Response<Option>()
                {
                    Data = option,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Option>> DeleteOptionAsync(string OptionId)
        {
            var option = await _optionRepository.GetOptionByIdAsync(OptionId);
            if (option == null)
            {
                return new Response<Option>()
                {
                    Message = "Option Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            await _optionRepository.DeleteOption(option);

            return new Response<Option>()
            {
                Message = "Option Successfully Deleted",
                ResponseCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
        }

        public async Task<Response<string>> UpdateOptionDetails(string OptionId, UpdateOptionDto updateOptionDto)
        {
            var option = await _optionRepository.GetOptionByIdAsync(OptionId);

            if (option != null)
            {
                option.Answer = updateOptionDto.Answer;
                var result = await _optionRepository.UpdateOptionAsync(option);

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

        public async Task<Response<PaginationModel<IEnumerable<GetAllOptionResponseDto>>>> GetAllOptionsAsync(int pageSize, int pageNumber)
        {
            var options = await _optionRepository.GetAllOptionsAsync();
            var response = _mapper.Map<IEnumerable<GetAllOptionResponseDto>>(options);

            if (options != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<GetAllOptionResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Option",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<GetAllOptionResponseDto>>>()
            {
                Data = null,
                Message = "No Registered Option",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<ICollection<Option>>> GetOptionsByQuestionAsync(string QuestionId)
        {
            var options = await _optionRepository.GetOptionByQuestionAsync(QuestionId);
            if (options != null)
            {
                return new Response<ICollection<Option>>()
                {
                    Data = options,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourses not found");
        }
    }
}
