using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FinalProject_CompProg.Data;
using FinalProject_CompProg.Interfaces;

namespace FinalProject_CompProg
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
            services.AddDbContext<FinalProjectContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FinalProjectContext"))); //Sets up the connection string
            services.AddMvc();
            services.AddSwaggerDocument();
            //Adds the context scripts for each table and their interface
            services.AddScoped<IStudentsContextDAO, StudentsContextDAO>();  
            services.AddScoped<IRestaurantsContextDAO, RestaurantsContextDAO>();
            services.AddScoped<IMusicContextDAO,MusicContextDAO>();
            services.AddScoped<IHobbiesContextDAO,HobbiesContextDAO>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FinalProjectContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tester v1"));
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            //context.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
