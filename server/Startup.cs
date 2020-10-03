using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Newtonsoft.Json.Converters;
using Server.Model.Data;
using Server.Model.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Server.Model;

namespace Server
{
    public class Startup
    {
        private readonly string reactSpecificOrigion = "ReactSpecificOrigions";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: reactSpecificOrigion,
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration
                                          .GetSection("ClientIP")
                                          .GetChildren()
                                          .Select(x => x.Value)
                                          .ToArray());
                                  });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                var settings = options.SerializerSettings;
                settings.DateFormatString = "yyyy-MM-dd";
                settings.Converters.Add(new StringEnumConverter());
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAutoMapper(options => 
                options.AddProfile(new MappingProfile()));

            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(reactSpecificOrigion);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
