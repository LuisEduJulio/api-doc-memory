namespace api_doc_memory.domain.Dtos
{
    public class PersonDeleteByIdDto
    {
        public PersonDeleteByIdDto(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}