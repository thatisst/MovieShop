using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Helpers;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieShop.API", Version = "v1" });
            });

            //every time you see 'IMovieService', RUN 'MovieService'
            services.AddTransient<IMovieService, MovieService>(); // whenever we see IMovieService as a constructor parameter, will replace that with MovieService Class; change here if we want to pass a new class as parameters
            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IAsyncRepository<Genre>, EfRepository<Genre>>();
            services.AddTransient<IAsyncRepository<Review>, EfRepository<Review>>();
            services.AddTransient<IAsyncRepository<Favorite>, EfRepository<Favorite>>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICurrentLogedInUser, CurrentLogedInUser>();

            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IJwtService, JwtService>();

            services.AddAutoMapper(typeof(Startup), typeof(MovieShopMappingProfile));

            services.AddDbContext<MovieShopDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            //http context available in MVC only, so need to inject to Infrustructure

            // look for token in HTTP header and decode the token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding
                                .UTF8
                                .GetBytes(Configuration
                                    ["TokenSettings:PrivateKey"]))
                    };
                });
            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder =
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieShop.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader().AllowAnyMethod().
                AllowCredentials();
            });

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
