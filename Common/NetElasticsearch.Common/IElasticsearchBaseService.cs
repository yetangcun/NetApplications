using Nest;

namespace NetElasticsearch.Common
{
    public interface IElasticsearchBaseService
    {
        void EsMapping<T>() where T : class;

        Task<bool> Add<T>(T data) where T : class;

        Task<List<T>> Query<T>() where T : class;

        Task<List<T>> QueryWhere<T>(Func<QueryContainerDescriptor<T>, QueryContainer> func) where T : class;

        Task<string> EsSqlQuery(string esServerAddr, QueryParam queryParam, EsSqlDataFormat format = EsSqlDataFormat.json);

        Task<bool> Del<T>(string kId) where T : class;
    }
}