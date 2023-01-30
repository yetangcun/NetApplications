using System.ComponentModel;

namespace NetApplication.Common.Model.EsModel
{
    [Description("espassrecordmodel")]
    public class EsPassRecord: EsBaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// es基类
    /// </summary>
    public class EsBaseModel
    {
        /// <summary>
        /// 唯一表示
        /// </summary>
        public string _id { get; set; }

        /// <summary>
        /// 索引|表明
        /// </summary>
        public string _index { get; set; }
    }
}
