namespace NetElasticsearch.Common
{
    public interface IElasticsearchBaseService
    {
        void EsMapping<T>() where T : class;
    }
}