using LearnWebAPI.Middlewares;
using LearnWebAPI.OptionModels;
using LearnWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LearnWebAPI
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
            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));

            services.Configure<AppsettingGroupOptions>(Configuration.GetSection("AppsettingGroup"));

            services.AddControllers();

            services.AddTransient<GlobalExceptionHandlerMiddleware>();

            //1. Transient

            services.AddTransient<ITeaService, TeaService>();
            services.AddTransient<IRestaurantService, RestaurantService>();

            //2. Scope

            //services.AddScoped<ITeaService, TeaService>();
            //services.AddScoped<IRestaurantService, RestaurantService>();

            //3. Singleton

            //services.AddSingleton<ITeaService, TeaService>();
            //services.AddSingleton<IRestaurantService, RestaurantService>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LearnWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the
        // HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearnWebAPI v1"));
            }

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
