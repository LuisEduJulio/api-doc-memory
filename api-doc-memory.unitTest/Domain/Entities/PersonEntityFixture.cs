using api_doc_memory.domain.Entities;
using Bogus;

namespace api_doc_memory.unitTest.Domain.Entities
{
    public class PersonEntityFixture
    {
        public PersonEntity PersonEntityMock()
        {
            var PersonEntityFixture = new Faker<PersonEntity>("pt_BR")
              .RuleFor(a => a.Name, faker => faker.Person.FirstName)
              .RuleFor(a => a.Age, faker => faker.Random.Number(30))
              .RuleFor(a => a.Id, faker => faker.Random.Number(10000));

            return PersonEntityFixture;
        }
        public List<PersonEntity> PersonEntityListMock()
        {
            var CustomerEntityListFixture = new List<PersonEntity>();

            for (int i = 0; i < 3; i++)
            {
                var CustomerEntityFixture = PersonEntityMock();

                CustomerEntityListFixture.Add(CustomerEntityFixture);
            }

            return CustomerEntityListFixture;
        }
    }
}