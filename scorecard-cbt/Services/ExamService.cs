using AutoMapper;
using scorecard_cbt.DTOs;
using scorecard_cbt.Interfaces;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace scorecard_cbt.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }
        public async Task<Response<ExamDetailResponseDto>> GetExamByIdAsync(string examId)
        {
            Exam exam = await _examRepository.GetExamByIdAsync(examId);

            if (exam != null)
            {
                var result = _mapper.Map<ExamDetailResponseDto>(exam);
                return new Response<ExamDetailResponseDto>()
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Successful",
                    ResponseCode = HttpStatusCode.OK
                };
            }

            throw new ArgumentException("Resourse not found");
        }
        public async Task<ExamResponseDto> RegisterExamAsync(ExamRegistrationDto registrationRequest)
        {
            Exam exam = _mapper.Map<Exam>(registrationRequest);
            await _examRepository.CreateExamAsync(exam);
            
            var answer = new ExamResponseDto
            {
                Id = exam.Id,
                Title = exam.Title,
                CourseId = exam.CourseId,
                ShortCode = exam.ShortCode,
                ScheduledStartDate = exam.ScheduledStartDate,
                ScheduledEndDate = exam.ScheduledEndDate
            };

            return answer;
        }
        public async Task<Response<Exam>> DeleteExamAsync(string examId)
        {
            var exam = await _examRepository.GetExamByIdAsync(examId);
            if (exam == null)
            {
                return new Response<Exam>()
                {
                    Message = "Exam Not Found",
                    ResponseCode = HttpStatusCode.NoContent,
                    IsSuccessful = false
                };
            }
            await _examRepository.Delete(exam);

            return new Response<Exam>()
            {
                Message = "Exam Successfully Deleted",
                ResponseCode = HttpStatusCode.OK,
                IsSuccessful = true
            };
        }
    }
}
