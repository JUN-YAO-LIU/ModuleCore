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
        //CH1-step1:�{���i�J�I
        /*Note:�{�����檺�i�J�I�A��C�y���ܹ����O��main�}�l*/
        public static void Main(string[] args)
        {
            //CH1-step2:�إ߭n�ƻ����ΪA�ȡC
            var host = CreateHostBuilder(args).Build();

            //�����Ʈw�ʧ@
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

        /*Nore: 1.�I�sStartup �o��Class�A���o�]�w���A�ȡC 
         2.Ū�Jappsetting.json���]�w�Ѽ�*/
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        #endregion

    }
}
