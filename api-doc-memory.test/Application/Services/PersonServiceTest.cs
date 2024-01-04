using api_doc_memory.application.Services;
using api_doc_memory.domain.Dtos;
using api_doc_memory.domain.Entities;
using api_doc_memory.domain.ModelViews;
using api_doc_memory.domain.Repositories;
using api_doc_memory.domain.Results;
using api_doc_memory.test.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace api_doc_memory.test.Application.Services
{
    public class PersonServiceTest
    {
        private readonly Mock<ILogger<PersonService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPersonRepository> _personRepositoryMock;
        private readonly PersonService _personServiceMock;
        public PersonServiceTest()
        {
            _loggerMock = new Mock<ILogger<PersonService>>();
            _mapperMock = new Mock<IMapper>();
            _personRepositoryMock = new Mock<IPersonRepository>();

            _personServiceMock = new PersonService(
                _loggerMock.Object,
                _personRepositoryMock.Object,
                 _mapperMock.Object);
        }
        [Fact(DisplayName = "GetByIdAsync: person exist return valid result")]
        public async Task GetByIdAsync_PersonExists_ReturnsValidResult()
        {
            // Arrange
            var id = 1;
            var personEntity = new PersonEntityFixture().PersonEntityMock();
            var personGetByIdDto = new PersonGetByIdDto(id);

            _personRepositoryMock
                .Setup(r => r.GetByIdAsync(personEntity.Id))
                .ReturnsAsync(new ResultRepository<PersonEntity>
                {
                    Success = true,
                    Data = personEntity,
                    Message = $"Person with Id {personEntity.Id} "
                });

            _mapperMock
                .Setup(m => m.Map<PersonGetModelView>(personEntity))
                .Returns(new PersonGetModelView());

            // Act
            var result = await _personServiceMock
                .GetByIdAsync(personGetByIdDto);

            // Assert
            Assert.True(result.Success);
            //Assert.Equal(personEntity, result.Data);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "GetByIdAsync: person exist return valid result")]
        public async Task GetByFiltersAsync_PersonsExists_ReturnsValidResult()
        {
            // Arrange
            var id = 1;
            var personEntity = new PersonEntityFixture().PersonEntityMock();
            var personEntityList = new PersonEntityFixture().PersonEntityListMock();
            var personGetByIdDto = new PersonGetByIdDto(id);

            _personRepositoryMock
                .Setup(r => r.GetByFiltersAsync(personEntity))
                .ReturnsAsync(new ResultRepository<List<PersonEntity>>
                {
                    Success = true,
                    Data = personEntityList
                });

            _mapperMock
                .Setup(m => m.Map<PersonGetAllModelView>(personEntity))
                .Returns(new PersonGetAllModelView());

            // Act
            //var result = await _personServiceMock
            //    .GetByFiltersAsync(personGetByIdDto);

            //// Assert
            //Assert.True(result.Success);
            ////Assert.Equal(personEntity, result.Data);
            //Assert.Null(result.Message);
        }
    }
}