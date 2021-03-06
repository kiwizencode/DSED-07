﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using IMSWebApp.Models;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace IMSWebApp
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
            services.AddDbContext<fishinaboxContext>
                (options => options.UseSqlServer(Configuration["Database:ConnectionString"]));
            /*  
             *  Enable Response Compression In ASP.NET Core
             *  http://www.binaryintellect.net/articles/85973b21-5466-413d-9cc5-f44c63686859.aspx
             */
            services.Configure<GzipCompressionProviderOptions>
                (options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>  {
                options.Providers.Add<GzipCompressionProvider>();
            });
            /* */
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            /*  
             *  Enable Response Compression In ASP.NET Core
             *  http://www.binaryintellect.net/articles/85973b21-5466-413d-9cc5-f44c63686859.aspx
             */
            app.UseResponseCompression();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
