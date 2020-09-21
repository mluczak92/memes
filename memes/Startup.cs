using memes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace memes {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            IMvcBuilder mvcBuilder = services.AddControllersWithViews();
            services.Configure<RouteOptions>(x => {
                x.LowercaseUrls = true;
            });
#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif

            services.AddSingleton<IPostsRepository, InMemoryPostsRepository>();
            services.AddTransient<IImageUploader, SimpleImageUploader>();
            services.AddTransient<ITagsSplitter, SimpleTagsSplitter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(x => {
                x.MapControllerRoute("default", "{controller=Posts}/{action=Index}");
            });
        }
    }
}
