using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Giraffe.ViewEngine.Mvc.Sample.Models;

namespace Giraffe.ViewEngine.Mvc.Sample.CSharp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var d =
                new Dictionary<(string, string),
                    Func<object, ViewDataDictionary, ModelStateDictionary, HtmlElements.XmlNode>>
                {
                    [("Home", "Index")] = Views.Home.Index,
                    [("Home", "Privacy")] = Views.Home.Privacy,
                    [("Home", "Error")] = GiraffeViewManualProviderModule.castF<ErrorViewModel>(Views.Home.Error)
                };

            services.AddSingleton<IGiraffeViewProvider>(new GiraffeViewManualProvider(d));
            services.AddMvc().AddGiraffeView();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
