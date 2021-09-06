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
        //CH1-step3:會先在Startup建立要甚麼應用服務。
        //Note:能註冊設定服務
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //CH1-step4:這邊就是設定的應用服務，設定了連結EntityFrameWork的資料庫服務。
            services.AddDbContext<ModuleContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            //沒設定看看
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
        //方法可用來指定應用程式對 HTTP 要求的回應方式。
        //能設定接收到http要求時，要預先做甚麼回應
        //常用的就是 MapControllerRoute
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //CH1-step5:預設程式，用戶端會接收報的字串。
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseSession();

            //常用的就是 MapControllerRoute
            //Note:依照URL的設定，會對應到相對應的頁面
            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapHub<GameHub>("/GameHub");
                });


        }
    }
}
