using api_doc_memory.application.Validators;
using api_doc_memory.domain.Dtos;
using api_doc_memory.domain.Entities;
using api_doc_memory.domain.ModelViews;
using api_doc_memory.domain.Repositories;
using api_doc_memory.domain.Results;
using api_doc_memory.domain.Services;
using api_doc_memory.utility.Helpers;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace api_doc_memory.application.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger<PersonService> _logger;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(
            ILogger<PersonService> logger,
            IPersonRepository personRepository,
            IMapper mapper)
        {
            _logger = logger;
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonAddModelView>> AddAsync(PersonAddDto PersonAddDto)
        {
            var validation = await new PersonAddDtoValidator()
                 .ValidateAsync(PersonAddDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<PersonAddModelView>(false, validation.Errors.First().ErrorMessage, new PersonAddModelView());

            var personEntityMapper = _mapper
                .Map<PersonEntity>(PersonAddDto);

            var personEntity = await _personRepository
                .AddAsync(personEntityMapper);

            if (!personEntity.Success) return ResultsHelpers
                    .ReturnResulService<PersonAddModelView>(false, personEntity.Message, _mapper.Map<PersonAddModelView>(personEntityMapper));

            var personAddModelView = _mapper
                .Map<PersonAddModelView>(personEntity.Data);

            return ResultsHelpers
                .ReturnResulService<PersonAddModelView>(personEntity.Success, "Create Person!", personAddModelView);
        }
        public async Task<ResultService<PersonUpdateModelView>> UpdateAsync(PersonUpdateDto personUpdateDto)
        {
            var validation = await new PersonUpdateDtoValidator()
                 .ValidateAsync(personUpdateDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<PersonUpdateModelView>(false, validation.Errors.First().ErrorMessage, new PersonUpdateModelView());

            var personEntityMapper = _mapper
                .Map<PersonEntity>(personUpdateDto);

            var personEntity = await _personRepository
                .UpdateAsync(personEntityMapper);

            if (!personEntity.Success) return ResultsHelpers
                  .ReturnResulService<PersonUpdateModelView>(false, personEntity.Message, _mapper.Map<PersonUpdateModelView>(personEntityMapper));

            var personUpdateModelView = _mapper
                .Map<PersonUpdateModelView>(personEntity.Data);

            return ResultsHelpers
                .ReturnResulService<PersonUpdateModelView>(personEntity.Success, "Update Person!", personUpdateModelView);
        }
        public async Task<ResultService<int>> DeleteAsync(PersonDeleteByIdDto personDeleteByIdDto)
        {
            var validation = await new PersonDeleteDtoValidator()
                .ValidateAsync(personDeleteByIdDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<int>(false, validation.Errors.First().ErrorMessage, personDeleteByIdDto.Id);

            var personEntity = await _personRepository
                .DeleteAsync(personDeleteByIdDto.Id);

            if (!personEntity.Success) return ResultsHelpers
                    .ReturnResulService<int>(false, personEntity.Message, personDeleteByIdDto.Id);

            return ResultsHelpers
                .ReturnResulService<int>(personEntity.Success, "Delete Person!", personDeleteByIdDto.Id);
        }
        public async Task<ResultService<PersonGetAllModelView>> GetByFiltersAsync(PersonFilterDto personFilterDto)
        {
            var validation = await new PersonFilterDtoValidator()
                .ValidateAsync(personFilterDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<PersonGetAllModelView>(false, validation.Errors.First().ErrorMessage, new PersonGetAllModelView());

            var personEntityMapper = _mapper
                .Map<PersonEntity>(personFilterDto);

            var personEntity = await _personRepository
                .GetByFiltersAsync(personEntityMapper);

            if (!personEntity.Success) return ResultsHelpers
                    .ReturnResulService<PersonGetAllModelView>(false, personEntity.Message, new PersonGetAllModelView());

            var personGetAllModelView = new PersonGetAllModelView();

            foreach (var data in personEntity.Data)
            {
                var personGetModelView = _mapper
                    .Map<PersonGetModelView>(data);

                personGetAllModelView
                    .PersonGetModelViewList
                    .Add(personGetModelView);
            }

            return ResultsHelpers
                .ReturnResulService<PersonGetAllModelView>(personEntity.Success, "List Person!", personGetAllModelView);
        }
        public async Task<ResultService<PersonGetModelView>> GetByIdAsync(PersonGetByIdDto personGetByIdDto)
        {
            var validation = await new PersonGetByIdDtoValidator().ValidateAsync(personGetByIdDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<PersonGetModelView>(false, validation.Errors.First().ErrorMessage, new PersonGetModelView());

            var personEntity = await _personRepository
                .GetByIdAsync(personGetByIdDto.Id);

            if (!personEntity.Success) return ResultsHelpers
                    .ReturnResulService<PersonGetModelView>(false, personEntity.Message, new PersonGetModelView());

            var personGetModelView = _mapper
                .Map<PersonGetModelView>(personEntity.Data);

            return ResultsHelpers
                .ReturnResulService<PersonGetModelView>(personEntity.Success, "Get Person!", personGetModelView);
        }
        public async Task<ResultService<PersonGetAllModelView>> GetAllAsync(PaginationDto paginationDto)
        {
            var validation = await new PaginationDtoValidator()
              .ValidateAsync(paginationDto);

            if (!validation.IsValid) return ResultsHelpers
                    .ReturnResulService<PersonGetAllModelView>(false, validation.Errors.First().ErrorMessage, new PersonGetAllModelView());

            var personEntity = await _personRepository
                 .GetAllAsync(paginationDto.Page, paginationDto.Count);

            if (!personEntity.Success) return ResultsHelpers
                    .ReturnResulService<PersonGetAllModelView>(false, personEntity.Message, new PersonGetAllModelView());

            var personGetAllModelView = new PersonGetAllModelView();

            foreach (var data in personEntity.Data)
            {
                var personGetModelView = _mapper
                    .Map<PersonGetModelView>(data);

                personGetAllModelView
                    .PersonGetModelViewList
                    .Add(personGetModelView);
            }

            return ResultsHelpers
                .ReturnResulService<PersonGetAllModelView>(personEntity.Success, "List Person!", personGetAllModelView);
        }
    }
}