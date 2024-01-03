namespace api_doc_memory.infraestructure.Entities
{
    public class AppSettings
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string? SqlServerConnection { get; set; }
    }
}