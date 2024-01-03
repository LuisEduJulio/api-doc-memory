namespace api_doc_memory.domain.Dtos
{
    public class PersonGetByIdDto
    {
        public PersonGetByIdDto(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}