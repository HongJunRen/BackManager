using BackManager.Domain;
using System.Linq;

namespace UnitOfWork.Customer
{
    public class SysUserService : ISysUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<SysUser> _sysUserRepository;
        public SysUserService(IUnitOfWork unitOfWork, IRepository<SysUser> sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
            _unitOfWork = unitOfWork;
        }

        public SysUser User()
        {
            return _sysUserRepository.FirstOrDefault(11);
        }
    }
}