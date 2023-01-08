namespace NetApplication.Common.Model.General
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageGeneralModel
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }
    }
}
