namespace NetApplication.Common.Model.Options
{
    public class RabbitmqOptions
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }   

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 虚拟机地址
        /// </summary>
        public string VirtualHost { get; set; }

    }
}
