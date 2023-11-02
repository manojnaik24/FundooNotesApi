using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Loger");
            NLog.GlobalDiagnosticsContext.Set("AMPTLDirectory", path);
            var loger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
             
            
                loger.Info("FundooNote is Started.");
                CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(web =>
                {
                    web.UseStartup<Startup>();
                }).ConfigureLogging(op =>
                {
                    op.ClearProviders();
                    op.SetMinimumLevel(LogLevel.Trace);
                }).UseNLog();
    }
}
