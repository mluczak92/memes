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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles(); // wwwroot/uploads and .css .js
            app.UseRouting(); // lowercaseurls
            app.UseEndpoints(x => {
                x.MapControllerRoute("specific tag_and page", "tag/{tag}/page/{page}", new { controller = "Posts", action = "Index" });
                x.MapControllerRoute("specific page", "page/{page}", new { controller = "Posts", action = "Index"});
                x.MapControllerRoute("specific tag", "tag/{tag}", new { controller = "Posts", action = "Index"});
                x.MapControllerRoute("default", "{controller=Posts}/{action=Index}");
            });

            MemesContext dbContext = app.ApplicationServices.GetRequiredService<MemesContext>();
            dbContext.Database.Migrate();

            IPostsRepository postsRepo = app.ApplicationServices.GetRequiredService<IPostsRepository>();
            ITagsSplitter splitter = app.ApplicationServices.GetRequiredService<ITagsSplitter>();
            new MemesSeeder(postsRepo, splitter).Seed();
        }
    }
}
