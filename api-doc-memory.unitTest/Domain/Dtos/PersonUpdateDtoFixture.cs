using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    public class PersonUpdateDtoFixture
    {
        public PersonUpdateDto PersonUpdateDtoMock()
        {
            var personUpdateDtoFixture = new Faker<PersonUpdateDto>("pt_BR")
              .RuleFor(a => a.Id, faker => faker.Random.Number(10))
              .RuleFor(a => a.Age, faker => faker.Random.Number(10))
              .RuleFor(a => a.Name, faker => faker.Person.FirstName);

            return personUpdateDtoFixture;
        }
    }
}