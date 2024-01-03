using api_doc_memory.domain.Entities;
using api_doc_memory.domain.Repositories;
using api_doc_memory.domain.Results;
using api_doc_memory.infraestructure.Factory;
using api_doc_memory.utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace api_doc_memory.infraestructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PersonRepository> _logger;
        public PersonRepository(AppDbContext dbContext, ILogger<PersonRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<ResultRepository<PersonEntity>> AddAsync(PersonEntity entity)
        {
            try
            {
                var newEntity = await _dbContext
                    .PersonEntitys
                    .AddAsync(entity);

                await _dbContext
                    .SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(true, newEntity.State.ToString(), newEntity.Entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(Exception.Message, "Error adding person");

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(false, Exception.Message, new PersonEntity());
            }
        }
        public async Task<ResultRepository<int>> DeleteAsync(int id)
        {
            try
            {
                var person = await _dbContext.PersonEntitys.FindAsync(id);

                if (person == null)
                {
                    return ResultsHelpers
                        .ReturnResultRepository<int>(false, $"Person with Id {id} not found", id);
                }

                _dbContext.PersonEntitys.Remove(person);

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers.ReturnResultRepository<int>(true, "Delete Person", id);
            }
            catch (Exception Exception)
            {
                _logger.LogError(Exception.Message, $"Error deleting person with Id {id}");

                return ResultsHelpers
                    .ReturnResultRepository<int>(false, Exception.Message, id);
            }
        }
        public async Task<ResultRepository<List<PersonEntity>>> GetAllAsync(int page, int count)
        {
            try
            {
                var persons = await _dbContext.PersonEntitys.Skip((page - 1) * count).Take(count).ToListAsync();

                return ResultsHelpers.ReturnResultRepository<List<PersonEntity>>(true, "Person List", persons);
            }
            catch (Exception Exception)
            {
                _logger.LogError(Exception.Message, "Error getting all persons");

                return ResultsHelpers
                    .ReturnResultRepository<List<PersonEntity>>(false, Exception.Message, new List<PersonEntity>());
            }
        }
        public async Task<ResultRepository<List<PersonEntity>>> GetByFiltersAsync(PersonEntity entity)
        {
            try
            {
                var persons = await _dbContext
                    .PersonEntitys
                    .Where(p => p.Name.Equals(entity.Name))
                    .ToListAsync();

                return ResultsHelpers
                    .ReturnResultRepository<List<PersonEntity>>(true, "Person Filter", persons);
            }
            catch (Exception Exception)
            {
                _logger.LogError(Exception.Message, "Error getting filter persons");

                return ResultsHelpers
                    .ReturnResultRepository<List<PersonEntity>>(false, Exception.Message, new List<PersonEntity>());
            }
        }
        public async Task<ResultRepository<PersonEntity>> GetByIdAsync(int id)
        {
            try
            {
                var person = await _dbContext.PersonEntitys.FindAsync(id);

                if (person == null)
                {
                    return ResultsHelpers
                        .ReturnResultRepository<PersonEntity>(false, $"Person with Id {id} not found", new PersonEntity());
                }

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(false, $"Person with Id {id} ", person);
            }
            catch (Exception Exception)
            {
                _logger
                    .LogError(Exception.Message, $"Error getting person with Id {id}");

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(false, Exception.Message, new PersonEntity());
            }
        }
        public async Task<ResultRepository<PersonEntity>> UpdateAsync(PersonEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(true, $"Person  updated", entity);
            }
            catch (Exception Exception)
            {
                _logger.LogError(Exception.Message, $"Error updating person with Id {entity.Id}");

                return ResultsHelpers
                    .ReturnResultRepository<PersonEntity>(false, Exception.Message, new PersonEntity());
            }
        }
    }
}