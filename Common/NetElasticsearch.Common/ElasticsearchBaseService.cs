using Nest;
using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.Http.Headers;
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

        private IHttpClientFactory _httpClientFactory;

        public ElasticsearchBaseService(
            IHttpClientFactory httpClientFactory,
            IOptions<ElasticsearchOptions> esOptions,
            ILogger<ElasticsearchBaseService> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

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

        public async Task<bool> Add<T>(T data) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
                return false;

            var res = await esClient.IndexAsync(data, i => i.Index(mapName));

            return res.IsValid;
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

        public async Task<bool> Del<T>(string kId) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
                return false;

            await esClient.DeleteAsync<T>(kId, s => s.Index(mapName));

            return false;
        }

        public async Task<List<T>> Query<T>() where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var query = new MatchAllQuery(); //查询全部

            var searchRes = await esClient.
                SearchAsync<T>(s => s.Index(mapName).
                Query(q => query));

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

        public async Task<List<T>> QueryWhere<T>(Func<QueryContainerDescriptor<T>, QueryContainer> func) where T : class
        {
            var mapName = getEsIndexName(typeof(T));
            if (string.IsNullOrWhiteSpace(mapName))
            {
                return null;
            }

            var searchRes = await esClient.
                SearchAsync<T>(s => s.Index(mapName).Query(func));

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

        /// <summary>
        /// ES之sql查询
        /// 向ES发起sql查询
        /// </summary>
        /// <param name="esHttpUrl">es的http地址：http://ip:9200/_xpack/sql?format=csv，http://ip:9200/_xpack/sql?format=json，http://ip:9200/_xpack/sql?format=txt </param>
        /// <param name="queryParam">query(就是sql: select * from employee where job='java')</param>
        public async Task<string> EsSqlQuery(string esServerAddr, QueryParam queryParam, EsSqlDataFormat format = EsSqlDataFormat.json)
        {
            var queryContent = new StringContent(JsonConvert.SerializeObject(queryParam));
            queryContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsync(esServerAddr, queryContent);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        #endregion

        #region 私有公共方法

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

        #endregion
    }


    public class QueryParam
    {
        public string query { get; set; }
    }

    /// <summary>
    /// es执行sql查询返回结果格式
    /// </summary>
    public enum EsSqlDataFormat
    {
        /// <summary>
        /// json
        /// </summary>
        json =1,

        /// <summary>
        /// cvs
        /// </summary>
        cvs = 2,

        /// <summary>
        /// 普通文本
        /// </summary>
        txt = 3
    }
}
