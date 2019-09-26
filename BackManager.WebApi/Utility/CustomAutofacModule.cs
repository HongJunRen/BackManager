using Autofac;
using BackManager.Domain;
using BackManager.Infrastructure;
using BackManager.Utility;
using Microsoft.AspNetCore.Mvc;
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

            if (StaticConstraint.dbType == DbType.SqlServer)
            {

                builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();//注册仓储泛型

                builder.RegisterGeneric(typeof(EfCoreRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();//注册仓储泛型

            }
            else
            {
                builder.RegisterGeneric(typeof(EfMySqlCoreRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();//注册仓储泛型

                builder.RegisterGeneric(typeof(EfMySqlCoreRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();//注册仓储泛型


            }
            //属性注入
            {
                var controllerBaseType = typeof(ControllerBase);
                builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                    .PropertiesAutowired();
            }
            builder.RegisterAssemblyTypes(typeof(SysUserService).Assembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}
