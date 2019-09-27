using System.Threading.Tasks;
using BackManager.Common.DtoModel;
using BackManager.Common.DtoModel.Model.Login;
using BackManager.Common.DtoModel.Model.RouterDto;
using BackManager.Domain;

namespace UnitOfWork.Customer
{
    public interface ISysMenuService : IDataEntityAsync<SysMenuDto>
    {
        Task<RouterDto> GetUserMenuList(long iD);
    }
}