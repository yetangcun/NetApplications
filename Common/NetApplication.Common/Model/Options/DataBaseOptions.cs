using NetApplication.Common.Enum.Common;

namespace NetApplication.Common.Model.Options
{
    /// <summary>
    /// 数据库配置项
    /// </summary>
    public class DataBaseOptions
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DbType { get; set; }

        /// <summary>
        /// 数据连接串
        /// </summary>
        public string DbConnectionString { get; set; }
    }
}
