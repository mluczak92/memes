using memes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace memes {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            IMvcBuilder mvcBuilder = services.AddControllersWithViews();
            services.AddSingleton<IPostsRepository, InMemoryPostsRepository>();
            services.AddTransient<IImageUploader, SimpleImageUploader>();

#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif
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
