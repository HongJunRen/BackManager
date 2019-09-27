using BackManager.Common.DtoModel.Model.RouterDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackManager.Common.DtoModel
{
    public class SysUserDto
    {
        public long ID { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public long DepartmentID { get; set; }


        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }





        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContractPhone { get; set; }

        /// <summary>
		/// 组名称
		/// </summary>
		public string GroupName { get; set; }

        /// 菜单权限
        /// </summary>
        public RouterDto MenuList { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
