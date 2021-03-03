using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using ODataTest.Models;
using ODataTest.Repositories;
using ODataTest.Services;

namespace ODataTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Students"));
    
            services.AddControllers();
            services.AddOData(opt => opt.AddModel(GetEdmModel()).Filter().Count().Expand().Select().Count().OrderBy());
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<StudentRepository>();
            services.AddTransient<StudentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ODataTest v1"));
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Student>("Students");
            
            return odataBuilder.GetEdmModel();
        }
    }
}