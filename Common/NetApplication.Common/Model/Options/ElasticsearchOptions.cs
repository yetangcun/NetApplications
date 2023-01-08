namespace NetApplication.Common.Model.Options
{
    /// <summary>
    /// es配置项
    /// </summary>
    public class ElasticsearchOptions
    {
        /// <summary>
        /// es服务ip
        /// </summary>
        public string EsServerIp { get; set; }

        /// <summary>
        /// es服务端口
        /// </summary>
        public int EsServerPort { get; set; }

        /// <summary>
        /// es服务地址
        /// </summary>
        public string EsServerAddr => $"http://{EsServerIp}:{EsServerPort}";
    }
}
