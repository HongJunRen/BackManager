using System;

namespace BackManager.Domain
{
    /// <summary>
    /// SysUserGroup
    /// </summary>
    public class SysUserGroup : AggregateRoot
    {

	


		/// <summary>
		/// 
		/// </summary>
		public long UserID { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public long GroupID { get; set; }


    }
}
