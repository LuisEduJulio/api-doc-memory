using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    public class PersonAddDtoFixture
    {
        public PersonAddDto PersonAddDtoMock()
        {
            var personAddDtoFixture = new Faker<PersonAddDto>("pt_BR")
              .RuleFor(a => a.Age, faker => faker.Random.Number(10))
              .RuleFor(a => a.Name, faker => faker.Person.FirstName);

            return personAddDtoFixture;
        }
    }
}