﻿using System.Threading.Tasks;
using BackManager.Common.DtoModel;
using BackManager.Common.DtoModel.Model.Login;
using BackManager.Domain;

namespace UnitOfWork.Customer
{
    public interface ISysUserService : IDataEntityAsync<SysUserDto>
    {
        SysUser User();
        Task<ApiResult<SysUserDto>> Login(LoginUserDto loginUserDto);
    }
}