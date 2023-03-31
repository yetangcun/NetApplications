using NetApplication.Common.Enum.Common;

namespace NetApplication.ICapServices.Model.Options
{
    /// <summary>
    /// Cap配置项
    /// </summary>
    public class CapOptions
    {
        /// <summary>
        /// 消息队列类型
        /// </summary>
        public MessageQueueType MessageQueueType { get; set; }

        /// <summary>
        /// Cap数据库连接串
        /// </summary>
        public string CapDbConnectionString { get; set; }


        /// <summary>
        /// 默认队列名
        /// </summary>
        public string DefaultQueueName { get; set; }
    }
}
