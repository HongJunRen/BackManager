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
        public ISysUserService _sysUserService { get; set; }
        public ISysMenuService _sysMenuService { get; set; }
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

                sysUser.ApiData.Token = "安全密钥,暂未实现";
                sysUser.ApiData.MenuList = await _sysMenuService.GetUserMenuList(sysUser.ApiData.ID);
            }

            return Ok(sysUser);
        }
    }
}