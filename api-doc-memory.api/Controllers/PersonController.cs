﻿using api_doc_memory.domain.Dtos;
using api_doc_memory.domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_doc_memory.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody] PersonAddDto entity)
        {
            var resultService = await _personService.AddAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getpersonbyid/{id}")]
        public async Task<IActionResult> PersonGetByIdAsync(int id)
        {

            var resultService = await _personService.GetByIdAsync(new PersonGetByIdDto(id));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getpersonall/{page}/{count}")]
        public async Task<IActionResult> PersonGetAllAsync(int page, int count)
        {

            var resultService = await _personService.GetAllAsync(new PaginationDto(page, count));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpGet("getpersonfilter")]
        public async Task<IActionResult> PersonGetByFilterAsync([FromQuery] PersonFilterDto entity)
        {

            var resultService = await _personService.GetByFiltersAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpPut("updateperson")]
        public async Task<IActionResult> PersonUpdateAsync([FromBody] PersonUpdateDto entity)
        {

            var resultService = await _personService.UpdateAsync(entity);

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
        [HttpDelete("deleteperson/{Id}")]
        public async Task<IActionResult> PersonDeleteAsync(int Id)
        {

            var resultService = await _personService.DeleteAsync(new PersonDeleteByIdDto(Id));

            if (!resultService.Success)
            {
                return NotFound(resultService);
            }

            return Ok(resultService);
        }
    }
}