using BackManager.Common.DtoModel;
using BackManager.Common.DtoModel.Model.Login;
using BackManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitOfWork.Customer;

namespace BackManager.WebApi.Controllers
{
    public class LoginController : BaseController
    {
        #region 属性注入
        public ISysMenuService _sysUserService { get; set; }
        #endregion

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginUserDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUserDto)
        {
            ApiResult<SysUserDto> sysUser = await _sysUserService.Login(loginUserDto);
            if (sysUser.Success)
            {

            }
            return Ok(sysUser);
        }
    }
}