using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    public class PersonGetByIdDtoFixture
    {
        public PersonGetByIdDto PersonGetByIdDtoMock()
        {
            var personGetByIdDtoFixture = new Faker<PersonGetByIdDto>("pt_BR")
              .RuleFor(a => a.Id, faker => faker.Random.Number(10));

            return personGetByIdDtoFixture;
        }
    }
}