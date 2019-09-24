using System;
using System.Collections.Generic;
using System.Text;

namespace BackManager.Domain.DomainDrive
{
    public class QueryParameter<T>
         where T : class
    {

        /// <summary>
        /// 每页显示条数 最小为1
        /// </summary>
        public int Rows { get; set; } = 10;

        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPage { get; set; } = true;
        /// <summary>
        /// 当前页码 最小为1
        /// </summary>
        private int _Page { get; set; } = 1;
        public int Page
        {
            get
            {
                if (!this.IsPage)
                {
                    _Page = -9999;
                }
                return _Page;
            }
            set
            {
                _Page = value;
            }
        }
        /// <summary>
        /// 是否降序
        /// </summary>
        public bool IsDesc { get; set; } = true;
        private string _Sort = "UpdatedAt";
        /// <summary>
        /// 排序字段默认为Id
        /// </summary>
        public string Sort
        {
            get
            {
                if (this.IsDesc && this._Sort.IndexOf("desc") == -1)
                {
                    if (string.IsNullOrEmpty(_Sort))
                        _Sort = "UpdatedAt";
                    _Sort = $"{_Sort}   desc";
                }
                return _Sort;
            }
            set
            {
                _Sort = value;
            }
        }

        /// </summary>
        /// <summary>
        /// 存储过程名称
        /// </summary>
        public string CommandText { get; set; }
       

        /// <summary>
        /// 总条数key
        /// </summary>
        public string TotalKey
        {
            get { return "@total"; }
        }
        /// <summary>
        /// 总页数key
        /// </summary>

        public string TotalPageKey
        {
            get { return "@totalPage"; }
        }

        

        public T Filter { get; set; }

        public TP FilterTo<TP>() where TP : class
        {
            if (this.Filter != null)
            {
                return this.Filter as TP;
            }
            return default(TP);
        }
    }
}
