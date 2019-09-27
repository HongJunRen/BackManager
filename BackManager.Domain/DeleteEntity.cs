using Mxlemon.Magic.Portal.DomainDrive;
using System;

namespace BackManager.Domain
{
    /// <summary>
    /// 删除基类
    /// </summary>
    public class DeleteEntity: IDeleteEntity
    {
        

        /// <summary>
        /// Desc:删除时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Desc:删除用户
        /// Default:
        /// Nullable:True
        /// </summary>           
        public long? DeleteUserId { get; set; }
        public int DeleteFlag { get; set; } = 0;
  
    }
}
