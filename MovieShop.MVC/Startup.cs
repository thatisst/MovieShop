using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Infrastructure.Services;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;

namespace MovieShop.MVC
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
            services.AddControllersWithViews();
            // Regestering our Classes for interfaces to be used across our application
            // .NET Core has built-in DI
            // .NET Framework did not have built-in DI, 
            //      we had to download 3rd party package or IOC, like Ninject, Autofac ...

            //every time you see 'IMovieService', RUN 'MovieService'
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieRepository, MovieRepository>();

            ////services.AddTransient<IGenreService, GenreService>();
            ////services.AddTransient<>(); //todo
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IAsyncRepository<Genre>, EfRepository<Genre>>();

            services.AddDbContext<MovieShopDbContext>(option => 
                option.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
