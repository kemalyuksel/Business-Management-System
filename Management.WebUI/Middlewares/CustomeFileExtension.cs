using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebUI.Middlewares
{
    public static class CustomeFileExtension
    {
        //public static void UseCustomStaticFile(this IApplicationBuilder app)
        //{
        //    app.UseStaticFiles(new StaticFileOptions()
        //    {
        //        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
        //        RequestPath = "/content"
        //    });

        //}
    }
}
