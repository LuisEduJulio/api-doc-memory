using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    public class PaginationDtoFixture
    {
        public PaginationDto PaginationDtoMock()
        {
            var paginationDtoFixture = new Faker<PaginationDto>("pt_BR")
              .RuleFor(a => a.Count, faker => faker.Random.Number(10))
              .RuleFor(a => a.Page, faker => faker.Random.Number(10));

            return paginationDtoFixture;
        }
    }
}