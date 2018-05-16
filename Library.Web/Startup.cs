using System;
using Library.Repositories;
using Library.Repositories.Books;
using Library.Services;
using Library.Web.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Web
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
            services.AddMvc();
            
            services.AddDistributedMemoryCache();
            
            services.AddSession(options =>
            {
                options.CookieName = ".MyApp.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
            
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient<ILibrarian, Librarian>();

            services.AddScoped<IBooksRepository, BooksRepository>();

            services.AddSingleton<IUsersRepository, UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMiddleware<UsageMiddleware>();
            
            app.Use(async (context, next) =>
            {
                context.Items["CurrentUserName"] = context.User.Identity.Name;
                await next();
            });
 
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текст: {context.Items["CurrentUserName"]}");
            });
        }
    }
}