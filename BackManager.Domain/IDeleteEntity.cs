using System;

namespace Mxlemon.Magic.Portal.DomainDrive
{
    /// <summary>
    /// 删除基类
    /// </summary>
    public interface IDeleteEntity
    {
        
        int DeleteFlag { get; set; }
        /// <summary>
        /// Desc:删除时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Desc:删除用户
        /// Default:
        /// Nullable:True
        /// </summary>           
         long? DeleteUserId { get; set; }
    }
}
