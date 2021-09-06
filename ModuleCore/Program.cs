using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModuleCore.Models;
using ModuleCore.Data;

namespace ModuleCore
{
    public class Program
    {
        //CH1-step1:程式進入點
        /*Note:程式執行的進入點，跟C語言很像都是由main開始*/
        public static void Main(string[] args)
        {
            //CH1-step2:建立要甚麼應用服務。
            var host = CreateHostBuilder(args).Build();

            //執行資料庫動作
            CreateDbIfNotExists(host);

            host.Run();
        }

        #region Function
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ModuleContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        /*Nore: 1.呼叫Startup 這個Class，取得設定的服務。 
         2.讀入appsetting.json的設定參數*/
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        #endregion

    }
}
