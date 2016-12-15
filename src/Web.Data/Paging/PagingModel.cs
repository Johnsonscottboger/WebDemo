using System.Collections.Generic;

namespace Web.Data.Paging {
    public class PagingModel<T>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> ModelList { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
