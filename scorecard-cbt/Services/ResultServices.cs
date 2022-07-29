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
    public class ResultServices : IResultServices
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultServices(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }
        public async Task<Response<ResultResponseDto>> GetResultByIdAsync(string ResultId)
        {
            var CbtResult = await _resultRepository.GetResultByIdAsync(ResultId);
            if (CbtResult != null)
            {
                var result = _mapper.Map<ResultResponseDto>(CbtResult);
                return new Response<ResultResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            throw new ArgumentException("Resourse not found");
        }

        public async Task<Response<Result>> DeleteResultAsync(string ResultId)
        {
            var CbtResult = await _resultRepository.GetResultByIdAsync(ResultId);
            if (CbtResult == null)
            {
                return new Response<Result>()
                {
                    Message = "Result Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            await _resultRepository.DeleteResult(CbtResult);

            return new Response<Result>()
            {
                Message = "Result Successfully Deleted",
                ResponseCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
        }

        public async Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetAllResultsAsync(int pageSize, int pageNumber)
        {
            var CbtResult = await _resultRepository.GetAllResultsAsync();
            var response = _mapper.Map<IEnumerable<ResultResponseDto>>(CbtResult);

            if (CbtResult != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Results",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
            {
                Data = null,
                Message = "No Result Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetResultsByUserIdAsync(int pageSize, int pageNumber, string UserId)
        {
            var CbtResult = await _resultRepository.GetResultByUserIdAsync(UserId);
            var response = _mapper.Map<IEnumerable<ResultResponseDto>>(CbtResult);

            if (CbtResult != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Results",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
            {
                Data = null,
                Message = "No Results Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetResultsByExamAsync(int pageSize, int pageNumber, string ExamId)
        {
            var CbtResult = await _resultRepository.GetResultByExamAsync(ExamId);
            var response = _mapper.Map<IEnumerable<ResultResponseDto>>(CbtResult);

            if (CbtResult != null)
            {
                var result = PaginationClass.PaginationAsync(response, pageSize, pageNumber);
                return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
                {
                    Data = result,
                    Message = "List of All Results",
                    ResponseCode = HttpStatusCode.OK,
                    IsSuccessful = true
                };
            }
            return new Response<PaginationModel<IEnumerable<ResultResponseDto>>>()
            {
                Data = null,
                Message = "No Results Found",
                ResponseCode = HttpStatusCode.NoContent,
                IsSuccessful = false
            };
        }

        public async Task<Response<Result>> CreateResultAsync(CreateResultDto createResult)
        {
            Result CbtResult = _mapper.Map<Result>(createResult);
            var result = await _resultRepository.CreateResultAsync(CbtResult);
            if (result)
            {
                return new Response<Result>()
                {
                    Data = CbtResult,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            throw new ArgumentException("Resourse not found");
        }
    }
}
