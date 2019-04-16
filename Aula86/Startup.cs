using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Aula86.AcessoDados;

namespace Aula86
{
    public class Startup
    {

        private IConfiguration _configuration;
       

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()

                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();

        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnecton = _configuration.GetConnectionString("MyWebAppDB");
            services.AddDbContext<MyWebAppContext>(options => options.UseMySql(sqlConnecton, b => b.MigrationsAssembly("Aula86")));

            services.AddMvc();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          /*  app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
            app.UseMvcWithDefaultRoute();
        }
    }
}
