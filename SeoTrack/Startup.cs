using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeoTrack.Controllers;
using SeoTrack.Services;

namespace SeoTrack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<Services.IPageLoader, Services.PageLoader>();
            services.AddTransient<GooglePageParser>();
            services.AddTransient<BingPageParser>();

            services.AddTransient<ISearchEngineParser, GoogleEngineParser>();
            services.AddTransient<ISearchEngineParser, BingEngineParser>();

            services.AddSingleton(new SeoSearchParameters(Const.SEO_SEARCH_TRAGET, Const.SEO_SEARCH_LIMIT));

            var googleParameters = new GoogleEngineParameters
            {
                SearchEngineName = Const.GOOGLE_ENGINE_NAME,
                UrlTemplate = Const.GOOGLE_ENGINE_URL_TEMPLATE
            };
            services.AddSingleton(googleParameters);

            var bingParameters = new BingEngineParameters
            {
                SearchEngineName = Const.BING_ENGINE_NAME,
                UrlTemplate = Const.BING_ENGINE_URL_TEMPLATE
            };
            services.AddSingleton(bingParameters);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
