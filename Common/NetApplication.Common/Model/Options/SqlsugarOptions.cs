using NetApplication.Common.Enum.Common;

namespace NetApplication.Common.Model.Options
{
    public class SqlsugarOptions
    {
        /// <summary>
        /// 业务编码
        /// </summary>
        public BusinessType BusinessCode { get; set; }

        /// <summary>
        /// 数据库连接串
        /// 主库串
        /// </summary>
        public string MasterConnectionStrings { get; set; }

        /// <summary>
        /// 数据库连接串
        /// 副库串
        /// </summary>
        public string SlaveConnectionStrings { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType DbType { get; set; }

        /// <summary>
        /// 是否自动关闭连接
        /// </summary>
        public bool IsAutoCloseConnection { get; set; }
    }
}
