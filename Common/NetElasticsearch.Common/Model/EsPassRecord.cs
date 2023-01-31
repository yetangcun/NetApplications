using Nest;
using System.ComponentModel;

namespace NetElasticsearch.Common.Model
{
    [Description("espassrecordmodel")]
    public class EsPassRecord
    {
        [Keyword(Name = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Keyword(Name = "No")]
        public string No { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Text(Name = "Name")]
        public string Name { get; set; }
    }

}
