using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShopsRUsRetailStoreAPI.Data;
using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using ShopsRUsRetailStoreAPI.Data.Repository.Concrete;
using ShopsRUsRetailStoreAPI.Data.Repository.Concrete.MongoDb.Context;
using ShopsRUsRetailStoreAPI.Middleware;
using ShopsRUsRetailStoreAPI.Services.Abstract;
using ShopsRUsRetailStoreAPI.Services.Concrete;

namespace ShopsRUsRetailStoreAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopsRUsRetailStoreAPI", Version = "v1" });
            });

            services.Configure<DbSettings>(Configuration.GetSection("MongoConnection"));

            services.AddSingleton<MongoDbContext>();

            services.AddScoped<IContext, MongoDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopsRUsRetailStoreAPI v1"));
            }

            app.UseExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
