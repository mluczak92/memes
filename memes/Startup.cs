using memes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace memes {
    public class Startup {
        IConfiguration cfg;

        public Startup(IConfiguration cfg) {
            this.cfg = cfg;
        }

        public void ConfigureServices(IServiceCollection services) {
#if DEBUG
            services.AddDbContext<MemesContext>(x => x.UseSqlServer(cfg["Data:MemesContext:DebugConnectionString"]));
#else
            services.AddDbContext<MemesContext>(x => x.UseSqlServer(cfg["Data:MemesContext:ReleaseConnectionString"]));
#endif
            IMvcBuilder mvcBuilder = services.AddControllersWithViews();
            services.Configure<RouteOptions>(x => {
                x.LowercaseUrls = true;
            });

#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();
#endif

            services.AddTransient<IPostsRepository, EFPostsRepository>();
            services.AddTransient<ITagsRepository, EFTagsRepository>();
            services.AddTransient<IImageUploader, SimpleImageUploader>();
            services.AddTransient<ITagsSplitter, EFUniqueTagsSplitter>();
            services.AddTransient<ISluggingService, SluggifySlugger>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles(); // wwwroot/uploads and .css .js
            app.UseRouting(); // lowercaseurls
            app.UseEndpoints(x => {
                x.MapControllerRoute("specific post page", "posts/{id:int:min(1)}/{slug}", new { controller = "Posts", action = "Single" });
                x.MapControllerRoute("specific tag and page", "tag/{tag}/page/{page:int:min(1)}", new { controller = "Posts", action = "Index" });
                x.MapControllerRoute("specific page", "page/{page:int:min(1)}", new { controller = "Posts", action = "Index"});
                x.MapControllerRoute("specific tag", "tag/{tag}", new { controller = "Posts", action = "Index"});
                x.MapControllerRoute("default", "{controller=Posts}/{action=Index}");
            });

            MemesContext dbContext = app.ApplicationServices.GetRequiredService<MemesContext>();
            dbContext.Database.Migrate();

            IPostsRepository postsRepo = app.ApplicationServices.GetRequiredService<IPostsRepository>();
            new MemesSeeder(postsRepo).Seed();
        }
    }
}
