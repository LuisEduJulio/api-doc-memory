using api_doc_memory.domain.Entities;
using api_doc_memory.domain.Results;

namespace api_doc_memory.domain.Repositories
{
    public interface IPersonRepository
    {
        Task<ResultRepository<PersonEntity>> AddAsync(PersonEntity entity);
        Task<ResultRepository<PersonEntity>> UpdateAsync(PersonEntity entity);
        Task<ResultRepository<List<PersonEntity>>> GetByFiltersAsync(PersonEntity entity);
        Task<ResultRepository<PersonEntity>> GetByIdAsync(int Id);
        Task<ResultRepository<List<PersonEntity>>> GetAllAsync(int Page, int Count);
        Task<ResultRepository<int>> DeleteAsync(int Id);
    }
}