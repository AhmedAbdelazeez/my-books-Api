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
using my_books.Data;
using my_books.Data.Services;
using my_books.Exceptoon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books
{
    public class Startup
    {
        public string connectionstring { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionstring = configuration.GetConnectionString("defaultconnectionstring");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<AppdbContext>(option => option.UseSqlServer(connectionstring));
            services.AddTransient<BookServices>();
            services.AddTransient<AuthorSevice>();
            services.AddTransient<PulisherService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "my_books_update_titlle", Version = "v2" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "my_books_ui v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ConfigureeBuildTnExptionHander();

          //  app.CongigureCustomExptionHandeler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           // AppDbIntilizer.Seed(app);
        }
    }
}
