using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackManager.Common.DtoModel;
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
        public async Task<IActionResult> GetUser(long ID)
        {
            return Ok(await _sysUserService.GetModelAsync(ID));
        }
        /// <summary>
        /// 用户新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserAdd([FromBody]SysUserDto model)
        {
            return Ok(await _sysUserService.InsertAsync(model));
        }
        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserUpdate([FromBody]SysUserDto model)
        {
            return Ok(await _sysUserService.UpdateAsync(model));
        }
        /// <summary>
        /// 用户分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserPage([FromBody]QueryParameter<SysUserPar> queryParameter)
        {
            return Ok(await _sysUserService.GridInfoAsync(queryParameter));
        }

        /// <summary>
        /// 用户测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LogOut()
        {
            return Ok(new { });
        }
    }
}