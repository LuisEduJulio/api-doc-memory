using api_doc_memory.domain.Dtos;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Dtos
{
    public class PersonFilterDtoFixture
    {
        public PersonFilterDto PersonFilterDtoMock()
        {
            var personFilterDtoFixture = new Faker<PersonFilterDto>("pt_BR")
              .RuleFor(a => a.Name, faker => faker.Person.FirstName)
              .RuleFor(a => a.Id, faker => faker.Random.Number(10000));

            return personFilterDtoFixture;
        }
    }
}