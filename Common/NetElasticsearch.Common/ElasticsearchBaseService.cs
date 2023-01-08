using Nest;
using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetApplication.Common.Model.Options;

namespace NetElasticsearch.Common
{
    public class ElasticsearchBaseService: IElasticsearchBaseService
    {
        public ILogger<ElasticsearchBaseService> _logger;

        private ElasticClient esClient = null;

        public ElasticsearchBaseService(
            IOptions<ElasticsearchOptions> esOptions,
            ILogger<ElasticsearchBaseService> logger)
        {
            _logger = logger;

            var esOption = esOptions.Value;

            esClient = new ElasticClient(new Uri(esOption.EsServerAddr));
        }

        public void EsMapping<T>() where T : class
        {
            var modelType = typeof(T);
            var mapName = getEsIndexName(modelType);
            if (!string.IsNullOrWhiteSpace(mapName))
                esClient.Indices.Create(mapName, e => e.Map<T>(m => m.AutoMap()));
        }

        #region 常用操作方法

        private string getEsIndexName(Type type)
        {
            var properties = type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (properties != null && properties.Length > 0)
            {
                var desAttrObj = (DescriptionAttribute)properties.GetValue(0);

                var mapName = desAttrObj.Description;

                return mapName;
            }

            return null;
        }

        public void Add<T>(T data) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return;
            }

            var res = esClient.Index(data, i => i.Index(mapName));
            if (!res.IsValid) // 插入失败
            {
                return;
            }
        }

        public void MulAdd<T>(List<T> datas) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return;
            }

            var bulkRes = esClient.Bulk(b => b.Index(mapName).IndexMany(datas));
            if (!bulkRes.IsValid) // 插入失败
            {
                return;
            }
        }

        public List<T> Query<T>() where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var query = new MatchAllQuery(); //查询全部

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).
                Query(q=>query));

            return searchRes.Documents.ToList();
        }

        public List<T> QueryPage<T>(Func<QueryContainerDescriptor<T>, QueryContainer> func, int pageIndex, int pageSize) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).
                Query(func).
                From((pageIndex - 1) * pageSize).Size(pageSize));

            return searchRes.Documents.ToList();
        }

        public List<T> QueryPage<T>(string queryString, int pageIndex, int pageSize) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).
                QueryOnQueryString(queryString).
                From((pageIndex - 1) * pageSize).Size(pageSize));

            return searchRes.Documents.ToList();
        }

        public List<T> QueryWhere<T>(Func<QueryContainerDescriptor<T>, QueryContainer> func) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).Query(func));

            return searchRes.Documents.ToList();
        }

        public List<T> QueryWhere<T>(string queryString) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).QueryOnQueryString(queryString));

            return searchRes.Documents.ToList();
        }

        public object QueryAggs<T>(Func<AggregationContainerDescriptor<T>, AggregationContainer> func) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).Size(0).Aggregations(func));

            object data = searchRes.Aggregations;
            return data;
        }

        public object QueryAggs<T>(AggregationDictionary pairs) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
                return null;

            var searchRes = esClient.
                Search<T>(s => s.Index(mapName).Size(0).Aggregations(pairs));

            object data = searchRes.Aggregations;
            return data;
        }

        public void QuerySql()
        {

        }

        #endregion
    }
}
