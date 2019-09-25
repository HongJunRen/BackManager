using BackManager.Common.DtoModel;
using BackManager.Domain;
using BackManager.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnitOfWork.Customer
{
    public class SysUserService : ISysUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SysUser> _sysUserRepository;
        private readonly IRepository<SysUserGroup> _sysUserGroupRepository;
        private readonly IRepository<SysGroup> _sysGroupRepository;
        public SysUserService(IUnitOfWork unitOfWork, IRepository<SysUser> sysUserRepository, IRepository<SysUserGroup> sysUserGroupRepository, IRepository<SysGroup> sysGroupRepository)
        {
            _sysUserRepository = sysUserRepository;
            _sysUserGroupRepository = sysUserGroupRepository;
            _sysGroupRepository = sysGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<ApiResult<long>> DeleteAsync(long[] ids)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResult<SysUserDto>> GetModelAsync(long id)
        {

            IQueryable<SysUser> sysUserQueryable = _sysUserRepository.GetAll();
            IQueryable<SysUserGroup> sysUserGroupQueryable = _sysUserGroupRepository.GetAll();
            IQueryable<SysGroup> sysGroupQueryable = _sysGroupRepository.GetAll();

            var userModel = from u in sysUserQueryable
                            join uug in sysUserGroupQueryable on u.Id equals uug.UserID
                            into uuug
                            from uuugModel in uuug.DefaultIfEmpty()
                            join ug in sysGroupQueryable on uuugModel.GroupID equals ug.Id
                            into uug
                            from uugModel in uug.DefaultIfEmpty()
                            select new SysUserDto()
                            {
                                LoginName = u.LoginName,
                                DepartmentID = u.DepartmentID,
                                NiceName = u.NiceName,
                                ContractPhone = u.ContractPhone,
                                GroupName = uugModel.GroupName
                            };
            SysUserDto sysUserDto = userModel.FirstOrDefault();
            if (sysUserDto != null)
            {
                return Task.FromResult(ApiResult<SysUserDto>.Ok(sysUserDto));
            }

            return Task.FromResult(ApiResult<SysUserDto>.Error());


        }

        public Task<ApiResult<PageResult<SysUserDto>>> GridInfoAsync<Par>(BackManager.Domain.DomainDrive.QueryParameter<Par> parameter) where Par : class
        {
            //Expression<Func<SysUser, bool>> x = null;
            //Expression<Func<SysUser, bool>> funcOrderby = null;
            //PageResult<SysUser> pageResult = _sysUserRepository.QueryPage(x, parameter.Rows, parameter.Page, funcOrderby);
            PageResult<SysUserDto> pageResult = _sysUserRepository.QueryPage<SysUserDto>(@"SELECT
                                                                                        sy.ID,
                                                                                        sy.UserType,
                                                                                        sy.NiceName,
                                                                                        sy.LoginName,
                                                                                        sy.ContractPhone,
                                                                                        sg.GroupName
                                                                                    FROM
                                                                                        sysuser sy
                                                                                        LEFT JOIN sysusergroup ssg ON sy.id = ssg.UserID
                                                                                        LEFT JOIN sysgroup sg ON ssg.GroupID = sg.id", parameter.Rows, parameter.Page, parameter.OrderBy);
                                                                                                return Task.FromResult(ApiResult<PageResult<SysUserDto>>.Ok(pageResult));


        }

        public async Task<ApiResult<long>> InsertAsync(SysUserDto model)
        {
            SysUser sysUser = AutoMapperHelper.MapTo<SysUser>(model);
            sysUser = await _sysUserRepository.InsertAsync(sysUser);
            return await Task.FromResult(ApiResult<long>.Ok(sysUser.Id));
        }

        public async Task<ApiResult<long>> UpdateAsync(SysUserDto model)
        {
            SysUser sysUser = AutoMapperHelper.MapTo<SysUser>(model);
            sysUser = await _sysUserRepository.UpdateAsync(sysUser);
            return await Task.FromResult(ApiResult<long>.Ok(sysUser.Id));
        }

        public SysUser User()
        {
            return _sysUserRepository.FirstOrDefault(11);
        }
    }
}