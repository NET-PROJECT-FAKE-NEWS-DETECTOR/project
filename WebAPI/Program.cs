using Application.Features.DecisionAlgorithm;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Console.WriteLine(NewsPrediction.Predict("Scientists decry Arctic oil expansion in letter to U.S. senators ", "NEW YORK (Reuters) - A group of 37 U.S.-based scientists whose research focuses on Arctic wildlife asked two U.S. senators in a letter on Thursday", "politicsNews"));
                    webBuilder.UseStartup<Startup>();
                    
                });
    }
}
