namespace NetElasticsearch.Common
{
    public interface IElasticsearchBaseService
    {
        void EsMapping<T>() where T : class;

        Task<bool> Add<T>(T data) where T : class;

        Task<List<T>> Query<T>() where T : class;
    }
}