using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShadowHome.Core.Common;
using ShadowHome.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowHome.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

          //var a =  ConfigurationManager.Configuration["DbInformation:ConnectionString"];
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime.Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModuleRegister());
            builder.RegisterModule<AutofacPropertityModuleReg>();
        }
        //public IServiceProvider ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();
        //    //services.Configure<CookiePolicyOptions>(options =>
        //    //{
        //    //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        //    //    options.CheckConsentNeeded = context => true;
        //    //    options.MinimumSameSitePolicy = SameSiteMode.None;
        //    //});

        //    //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        //    return RegisterAutofac(services); //ע��Autofac
        //}


        /// <summary>
        /// ע��Autofac
        /// </summary>
        //private static IServiceProvider RegisterAutofac(IServiceCollection services)
        //{
        //    //ʵ����Autofac����
        //    var builder = new ContainerBuilder();
        //    //��services�еķ�����䵽Autofac��
        //    builder.Populate(services);
        //    //��ģ�����ע��
        //    builder.RegisterModule<AutofacModuleRegister>();
        //    //��������
        //    var container = builder.Build();
        //    //������IoC�����ӹ�Core����DI����
        //    return new AutofacServiceProvider(container);
        //}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
