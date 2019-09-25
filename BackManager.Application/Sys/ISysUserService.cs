using BackManager.Common.DtoModel;
using BackManager.Domain;

namespace UnitOfWork.Customer
{
    public interface ISysUserService:IDataEntityAsync<SysUserDto>
    {
        SysUser User();
    }
}