using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BackManager.Utility;
using BackManager.WebApi.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using UnitOfWork;

namespace BackManager.WebApi
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            StaticConstraint.Init(s => configuration[s]);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region CORS

            //����ڶ��ַ������������ԣ��ǵ��±�app������

            services.AddCors(c =>
            {
                //һ��������ַ���
                c.AddPolicy("LimitRequests", policy =>
                {
                    // ֧�ֶ�������˿ڣ�ע��˿ںź�Ҫ��/б�ˣ�����localhost:8000/���Ǵ��
                    // ע�⣬http://127.0.0.1:1818 �� http://localhost:1818 �ǲ�һ���ģ�����д����
                    policy
                    .WithOrigins("http://localhost:8088", "https://localhost:44322")
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });

            #endregion
            //services.AddControllers();

            // ���߽�Controller���뵽Services��
            services.AddControllersWithViews().AddControllersAsServices().AddNewtonsoftJson(options =>
            {
                //JSON����ĸСд���
                options.SerializerSettings.ContractResolver =
                    new Newtonsoft.Json.Serialization.DefaultContractResolver();

                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            #region swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            #endregion

            services.AddDbContext<UnitOfWorkDbContext>(options =>
            {
                if (Configuration.GetConnectionString("DbType").ToEnum<DbType>() == DbType.SqlServer)
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServerConneceftionString"));
                else
                    options.UseMySQL(Configuration.GetConnectionString("MySqlConnectionString"));

            });

            //services.AddDbContext<UnitOfWorkDbContext>(options =>
            //   options.UseMySql("Data Source=localhost;port=3306;Initial Catalog=magicadmin;uid=root;password=123456;")
            //   );
        }
        //ע��AOP
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {


            containerBuilder.RegisterModule<MyAutofacModule>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();



            #region swagger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            #endregion
            app.UseRouting();


            app.UseAuthorization();

            app.UseCors("LimitRequests");//�� CORS �м����ӵ� web Ӧ�ó��������, �������������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
