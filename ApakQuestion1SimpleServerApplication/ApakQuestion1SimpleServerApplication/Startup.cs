using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApakQuestion1SimpleServerApplication.DataAccess;
using ApakQuestion1SimpleServerApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ApakQuestion1SimpleServerApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserDao, UserDao>();
            services.AddSingleton<IUserLookup, UserLookup>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
