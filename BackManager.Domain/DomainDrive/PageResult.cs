using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackManager.Domain
{
    public class PageResult<T>
    {
        /// <summary>
        /// 返回总页数
        /// </summary>
        public int PageTotal { get; set; }
     
        [JsonProperty("rows")]
        public IEnumerable<T> Rows { get; set; }
        /// <summary>
        /// 总条数(vue)
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        public void SetTotalCount(int rows)
        {
            if (this.Total > 0)
            {
                if (this.Total % rows == 0)
                {
                    this.PageTotal = this.Total / rows;
                }
                else
                {
                    this.PageTotal = (this.Total / rows) + 1;
                }
            }
        }
    }

}
