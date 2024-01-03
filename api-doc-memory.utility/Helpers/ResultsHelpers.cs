using api_doc_memory.domain.Results;

namespace api_doc_memory.utility.Helpers
{
    public static class ResultsHelpers
    {
        public static ResultService<T> ReturnResulService<T>(bool Success, string Message, T TEntity)
        {
            var ResultService = new ResultService<T>()
            {
                Data = TEntity,
                Message = Message,
                Success = Success
            };

            return ResultService;
        }
        public static ResultService<List<T>> ReturnResulService<T>(bool Success, string Message, List<T> TEntity)
        {
            var ResultService = new ResultService<List<T>>()
            {
                Data = TEntity,
                Message = Message,
                Success = Success
            };

            return ResultService;
        }
        public static ResultRepository<T> ReturnResultRepository<T>(bool Success, string Message, T TEntity)
        {
            var resultRepository = new ResultRepository<T>()
            {
                Data = TEntity,
                Message = Message,
                Success = Success
            };

            return resultRepository;
        }
        public static ResultRepository<List<T>> ReturnResultRepository<T>(bool Success, string Message, List<T> TEntity)
        {
            var resultRepository = new ResultRepository<List<T>>()
            {
                Data = TEntity,
                Message = Message,
                Success = Success
            };

            return resultRepository;
        }
    }
}