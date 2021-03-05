using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;

namespace WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:3000"));
            });

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
            //for using different modules
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

            //singleton for Brands 
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            ////singleton for Car 
            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();
            ////singleton for Color 
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();
            ////singleton for Customer
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            ////singleton for Rental
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();
            ////singleton for User
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
