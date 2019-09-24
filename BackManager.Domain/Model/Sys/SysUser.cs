using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackManager.Domain
{
    /// <summary>
    /// SysUser
    /// </summary>
    //[Table("SysUser")]
    public class SysUser : AggregateRoot
    {



        /// <summary>
        /// 所属部门
        /// </summary>
        public long DepartmentID { get; set; }


        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }


        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContractPhone { get; set; }


        /// <summary>
        /// 用户类型 1：技术  2：商务    3：营运  4：社群
        /// </summary>
        public int? UserType { get; set; }


        /// <summary>
        /// 1:激活  2:禁用
        /// </summary>
        public int? UserState { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatedUserId { get; set; }


        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }


        /// <summary>
        /// 更新人
        /// </summary>
        public long? UpdatedUserId { get; set; }


        /// <summary>
        /// 删除标记  0：默认 1：删除
        /// </summary>
        public int DeleteFlag { get; set; }


        /// <summary>
        /// 删除人
        /// </summary>
        public DateTime? DeletedAt { get; set; }


        /// <summary>
        /// 删除人
        /// </summary>
        public long? DeleteUserId { get; set; }


        /// <summary>
        /// 是否为管理员  0:否 1:是
        /// </summary>
        public bool IsAdmin { get; set; }


    }
}
