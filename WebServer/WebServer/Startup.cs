﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebServer.Data;

namespace WebServer
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            string name = "Boria";
            Animal animal = dbContext.Animals.SingleOrDefault(a => a.Name == name);
            if (animal == null)
            {
                animal = new Animal()
                {
                    Name = "Boria",
                    Bread = "Manul",
                    DateBirth = new DateTime(2018, 12, 12),
                    Image = "https://images.earthtouchnews.com/media/179015/06_02_2014_manul_Pallass-cat_1.jpg"
                };
                dbContext.Animals.Add(animal);
                dbContext.SaveChanges();
            }
            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
