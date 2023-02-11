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
        /// 主数据连接串
        /// </summary>
        public string MasterConnectionString { get; set; }

        /// <summary>
        /// 副数据库连接串
        /// </summary>
        public string SlaveConnectionString { get; set; }
    }
}
