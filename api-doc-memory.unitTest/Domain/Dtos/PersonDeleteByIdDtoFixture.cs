using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    internal class PersonDeleteByIdDtoFixture
    {
        public PersonDeleteByIdDto PersonDeleteByIdDtoMock()
        {
            var personDeleteByIdDtoFixture = new Faker<PersonDeleteByIdDto>("pt_BR")
              .RuleFor(a => a.Id, faker => faker.Random.Number(10));

            return personDeleteByIdDtoFixture;
        }
    }
}