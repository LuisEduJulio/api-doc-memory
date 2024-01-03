using api_doc_memory.domain.Dtos;
using api_doc_memory.domain.ModelViews;
using api_doc_memory.domain.Results;

namespace api_doc_memory.domain.Services
{
    public interface IPersonService
    {
        Task<ResultService<PersonAddModelView>> AddAsync(PersonAddDto addCustomerDto);
        Task<ResultService<PersonUpdateModelView>> UpdateAsync(PersonUpdateDto personUpdateDto);
        Task<ResultService<PersonGetAllModelView>> GetByFiltersAsync(PersonFilterDto personFilterDto);
        Task<ResultService<PersonGetAllModelView>> GetAllAsync(PaginationDto paginationDto);
        Task<ResultService<PersonGetModelView>> GetByIdAsync(PersonGetByIdDto personGetByIdDto);
        Task<ResultService<int>> DeleteAsync(PersonDeleteByIdDto personDeleteByIdDto);
    }
}