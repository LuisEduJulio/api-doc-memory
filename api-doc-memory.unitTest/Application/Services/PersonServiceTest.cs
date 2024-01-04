using api_doc_memory.application.Services;
using api_doc_memory.domain.Entities;
using api_doc_memory.domain.ModelViews;
using api_doc_memory.domain.Repositories;
using api_doc_memory.domain.Results;
using api_doc_memory.unitTest.Domain.Dtos;
using api_doc_memory.unitTest.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace api_doc_memory.unitTest.Application.Services
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
            var PersonGetByIdDtoMock = new PersonGetByIdDtoFixture().PersonGetByIdDtoMock();
            var personEntity = new PersonEntityFixture().PersonEntityMock();

            _personRepositoryMock
                .Setup(r => r.GetByIdAsync(PersonGetByIdDtoMock.Id))
                .ReturnsAsync(new ResultRepository<PersonEntity>
                {
                    Success = true,
                    Data = personEntity,
                    Message = $"Person with Id {PersonGetByIdDtoMock.Id} "
                });

            _mapperMock
                .Setup(m => m.Map<PersonGetModelView>(personEntity))
                .Returns(new PersonGetModelView());

            // Act
            var result = await _personServiceMock
                .GetByIdAsync(PersonGetByIdDtoMock);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "GetByFiltersAsync: person filters exist return valid result")]
        public async Task GetByFiltersAsync_PersonsExists_ReturnsValidResult()
        {
            // Arrange
            var personEntity = new PersonEntityFixture().PersonEntityMock();
            var personEntityList = new PersonEntityFixture().PersonEntityListMock();
            var PersonFilterDtoMock = new PersonFilterDtoFixture().PersonFilterDtoMock();

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

            //Act
            var result = await _personServiceMock
                .GetByFiltersAsync(PersonFilterDtoMock);

            //// Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "GetAllAsync: person list all exist return valid result")]
        public async Task GetAllAsync_PersonsExists_ReturnsValidResult()
        {
            // Arrange
            var personEntity = new PersonEntityFixture().PersonEntityMock();
            var personEntityList = new PersonEntityFixture().PersonEntityListMock();
            var PaginationDtoMock = new PaginationDtoFixture().PaginationDtoMock();

            _personRepositoryMock
                .Setup(r => r.GetAllAsync(PaginationDtoMock.Count, PaginationDtoMock.Page))
                .ReturnsAsync(new ResultRepository<List<PersonEntity>>
                {
                    Success = true,
                    Data = personEntityList
                });

            _mapperMock
                .Setup(m => m.Map<PersonGetAllModelView>(personEntity))
                .Returns(new PersonGetAllModelView());

            //Act
            var result = await _personServiceMock
                .GetAllAsync(PaginationDtoMock);

            //// Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "AddAsync: person insert return valid result")]
        public async Task AddAsync_PersonsInsert_ReturnsValidResult()
        {
            // Arrange
            var PersonAddDtoMock = new PersonAddDtoFixture().PersonAddDtoMock();
            var personEntity = new PersonEntityFixture().PersonEntityMock();

            _personRepositoryMock
                .Setup(r => r.AddAsync(personEntity))
                .ReturnsAsync(new ResultRepository<PersonEntity>
                {
                    Success = true,
                    Data = personEntity
                });

            _mapperMock
                .Setup(m => m.Map<PersonAddModelView>(personEntity))
                .Returns(new PersonAddModelView());

            //Act
            var result = await _personServiceMock
                .AddAsync(PersonAddDtoMock);

            //// Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "UpdateAsync: person update return valid result")]
        public async Task UpdateAsync_PersonsUpdate_ReturnsValidResult()
        {
            // Arrange
            var PersonUpdateDtoMock = new PersonUpdateDtoFixture().PersonUpdateDtoMock();
            var personEntity = new PersonEntityFixture().PersonEntityMock();

            _personRepositoryMock
                .Setup(r => r.UpdateAsync(personEntity))
                .ReturnsAsync(new ResultRepository<PersonEntity>
                {
                    Success = true,
                    Data = personEntity
                });

            _mapperMock
                .Setup(m => m.Map<PersonUpdateModelView>(personEntity))
                .Returns(new PersonUpdateModelView());

            //Act
            var result = await _personServiceMock
                .UpdateAsync(PersonUpdateDtoMock);

            //// Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "DeleteAsync: person delete return valid result")]
        public async Task DeleteAsync_PersonsDelete_ReturnsValidResult()
        {
            // Arrange
            var PersonDeleteByIdDtoMock = new PersonDeleteByIdDtoFixture().PersonDeleteByIdDtoMock();
            var personEntity = new PersonEntityFixture().PersonEntityMock();

            _personRepositoryMock
                .Setup(r => r.UpdateAsync(personEntity))
                .ReturnsAsync(new ResultRepository<PersonEntity>
                {
                    Success = true,
                    Data = personEntity
                });

            _mapperMock
                .Setup(m => m.Map<int>(personEntity.Id))
                .Returns(PersonDeleteByIdDtoMock.Id);

            //Act
            var result = await _personServiceMock
                .DeleteAsync(PersonDeleteByIdDtoMock);

            //// Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
        }
    }
}