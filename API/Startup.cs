using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;               
        }

        public void ConfigureServices(IServiceCollection services){           
            services.AddControllers();
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1",new OpenApiInfo{Title="WebAPIv5",Version="1.0.0"});
            });
              /*services.AddHealthChecks();
              services.AddMvc();*/
              services.AddDbContext<StoreContext>(x=>
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
        }

        // this method is called by runtime
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","API V1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpopints =>{
                endpopints.MapControllers();
            });
        }
    }
}