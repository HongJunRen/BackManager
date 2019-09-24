using Autofac;
using BackManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UnitOfWork
{
    public static class UnitOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();//在同一次请求中，获取多次对象得到的是同一个对象

            return services;
        }

        public static void AddUnitOfWork<TContext>(this ContainerBuilder services) where TContext : DbContext
        {
            services.RegisterType<UnitOfWork<TContext>>().As<IUnitOfWork>().InstancePerLifetimeScope();//：同一个Lifetime生成的对象是同一个实例

            //services.RegisterGeneric(typeof(UnitOfWork<TContext>)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();//注册仓储泛型
            //InstancePerLifetimeScope：同一个Lifetime生成的对象是同一个实例

            //SingleInstance：单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象；

            //InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
        }
    }
}