using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;

namespace Sani.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddMongo(Configuration.GetSection("ConnectionStrings"));
            
            services.AddMvc();

            //services.AddScoped<IApoiadoRepository, ApoiadoRepository>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sani API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Microsoft.AspNetCore.Cors.EnableCors("AllowAll")]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseStatusCodePages();
            //env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.MapWhen(context => context.Request.Path == "/missingpage", builder => { });

            app.Map("/error", error =>
            {
                error.Run(async context =>
                {
                    var builder = new StringBuilder();
                    builder.AppendLine("<html><body>");
                    builder.AppendLine("An error occurred.<br />");
                    var path = context.Request.Path.ToString();
                    if (path.Length > 1)
                    {
                        builder.AppendLine("Status Code: " +
                            HtmlEncoder.Default.Encode(path.Substring(1)) + "<br />");
                    }
                    var referrer = context.Request.Headers["referer"];
                    if (!string.IsNullOrEmpty(referrer))
                    {
                        builder.AppendLine("Return to <a href=\"" +
                            HtmlEncoder.Default.Encode(referrer) + "\">" +
                            WebUtility.HtmlEncode(referrer) + "</a><br />");
                    }
                    builder.AppendLine("</body></html>");
                    byte[] bodyBytes = Encoding.Unicode.GetBytes(builder.ToString());

                    context.Response.ContentType = "text/html";
                    await context.Response.Body.WriteAsync(bodyBytes, 0, bodyBytes.Length);
                });
            });
            #region snippet_AppRun
            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("throw"))
                {
                    throw new Exception("Exception triggered!");
                }
                var builder = new StringBuilder();
                builder.AppendLine("<html><body>Hello World!");
                builder.AppendLine("<ul>");
                builder.AppendLine("<li><a href=\"/?throw=true\">Throw Exception</a></li>");
                builder.AppendLine("<li><a href=\"/missingpage\">Missing Page</a></li>");
                builder.AppendLine("</ul>");
                builder.AppendLine("</body></html>");
                byte[] bodyBytes = Encoding.Unicode.GetBytes(builder.ToString());

                context.Response.ContentType = "text/html";
                await context.Response.Body.WriteAsync(bodyBytes, 0, bodyBytes.Length);
            });
            #endregion
            */

            app.UseCors("AllowAll");
            app.UseMvc();

            app.UseMvcWithDefaultRoute();
            /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });*/

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sani API V1");
            });
        }
    }
}
