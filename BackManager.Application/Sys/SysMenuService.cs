using BackManager.Common.DtoModel;
using BackManager.Common.DtoModel.Model.Login;
using BackManager.Domain;
using BackManager.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitOfWork.Customer
{
    public class SysMenuService : ISysMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SysMenu> _sysUserRepository;
        
        public SysMenuService(IUnitOfWork unitOfWork, IRepository<SysMenu> sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResult<long>> DeleteAsync(long[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<SysUserDto>> GetModelAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PageResult<SysUserDto>>> GridInfoAsync<Par>(BackManager.Domain.DomainDrive.QueryParameter<Par> parameter) where Par : class
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<long>> InsertAsync(SysUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<long>> InsertAsync(SysMenuDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<SysUserDto>> Login(LoginUserDto loginUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<long>> UpdateAsync(SysUserDto model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<long>> UpdateAsync(SysMenuDto model)
        {
            throw new NotImplementedException();
        }

        public SysUser User()
        {
            throw new NotImplementedException();
        }

        Task<ApiResult<SysMenuDto>> IDataEntityAsync<SysMenuDto>.GetModelAsync(long id)
        {
            throw new NotImplementedException();
        }

        Task<ApiResult<PageResult<SysMenuDto>>> IDataEntityAsync<SysMenuDto>.GridInfoAsync<Par>(BackManager.Domain.DomainDrive.QueryParameter<Par> parameter)
        {
            throw new NotImplementedException();
        }
    }
}