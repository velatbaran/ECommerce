using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ECommerce.Web.Middleware
{
    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");
            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = "/modules"
            };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
