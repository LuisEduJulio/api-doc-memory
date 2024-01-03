namespace api_doc_memory.domain.ModelViews
{
    public class PersonGetAllModelView
    {
        public PersonGetAllModelView()
        {
            PersonGetModelViewList = new List<PersonGetModelView>();
        }
        public List<PersonGetModelView> PersonGetModelViewList { get; set; }

    }
}