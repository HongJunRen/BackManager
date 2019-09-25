using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackManager.Common.DtoModel.Model.SysModel.QueryParameter;
using BackManager.Domain.DomainDrive;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Customer;

namespace BackManager.WebApi.Controllers.Sys
{
    public class SysUserController : BaseController
    {
        private readonly ISysUserService _sysUserService;
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// 用户测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_sysUserService.User());
        }

        /// <summary>
        /// 用户测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> UserPage(QueryParameter<SysUserPar> queryParameter)
        {
            return Ok(await _sysUserService.GridInfoAsync(queryParameter));
        }
    }
}