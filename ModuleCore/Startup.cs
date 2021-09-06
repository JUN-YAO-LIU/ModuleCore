using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModuleCore.Hubs;

namespace ModuleCore
{
    public class Startup
    {

        //reference:https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/startup?view=aspnetcore-5.0
        //CH1-step3:�|���bStartup�إ߭n�ƻ����ΪA�ȡC
        //Note:����U�]�w�A��
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //CH1-step4:�o��N�O�]�w�����ΪA�ȡA�]�w�F�s��EntityFrameWork����Ʈw�A�ȡC
            services.AddDbContext<ModuleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            //�S�]�w�ݬ�
            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //��k�i�Ψӫ��w���ε{���� HTTP �n�D���^���覡�C
        //��]�w������http�n�D�ɡA�n�w�����ƻ�^��
        //�`�Ϊ��N�O MapControllerRoute
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //CH1-step5:�w�]�{���A�Τ�ݷ|���������r��C
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseSession();

            //�`�Ϊ��N�O MapControllerRoute
            //Note:�̷�URL���]�w�A�|������۹���������
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapHub<GameHub>("/GameHub");
                });


        }
    }
}
