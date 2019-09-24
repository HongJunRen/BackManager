using Autofac;
using BackManager.Domain;
using BackManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.Customer;

namespace BackManager.WebApi.Utility
{
    public class MyAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //使用扩展方法注入Uow依赖
            builder.AddUnitOfWork<UnitOfWorkDbContext>();
            //使用默认方法注入Uow依赖

        

            builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();//注册仓储泛型

            builder.RegisterGeneric(typeof(EfCoreRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();//注册仓储泛型




            builder.RegisterAssemblyTypes(typeof(SysUserService).Assembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}
