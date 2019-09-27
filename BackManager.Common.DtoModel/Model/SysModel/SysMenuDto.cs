using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackManager.Common.DtoModel
{
    public class SysMenuDto
    {
        public long ID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>

        public string Name { get; set; }


        /// <summary>
        /// 菜单图标
        /// </summary>

        public string Icon { get; set; }


        /// <summary>
        /// 父节点ID
        /// </summary>
        public long? FatherID { get; set; }


        /// <summary>
        /// Url 地址
        /// </summary>

        public string Url { get; set; }


        /// <summary>
        /// 分类
        /// </summary>
        public int MenuCategory { get; set; }

        /// <summary>
        /// 状态 0:启用 1:禁用
        /// </summary>
        public int MenuState { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Orderby { get; set; }


        /// <summary>
        /// vue路由path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 下级菜单集合
        /// </summary>
        [JsonProperty("children")]
        public List<SysMenuDto> Children { get; set; }

    }
}
