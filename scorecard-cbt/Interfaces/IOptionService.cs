using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using scorecard_cbt.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IOptionService
    {
        Task<Response<Option>> CreateOptionAsync(string QuestionId, OptionRequestDto createOption);
        Task<Response<Option>> DeleteOptionAsync(string OptionId);
        Task<Response<PaginationModel<IEnumerable<GetAllOptionResponseDto>>>> GetAllOptionsAsync(int pageSize, int pageNumber);
        Task<Response<OptionDetailResponseDto>> GetOptionByIdAsync(string OptionId);
        Task<Response<ICollection<Option>>> GetOptionsByQuestionAsync(string QuestionId);
        Task<Response<string>> UpdateOptionDetails(string OptionId, UpdateOptionDto updateOptionDto);
    }
}