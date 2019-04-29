using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorServerSideRealWorld
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<Services.IJwtService, Services.JwtService>();
            services.AddTransient<Services.IConsoleLogService, Services.ConsoleLogService>();
            services.AddTransient<Services.ArticlesService>();
            services.AddTransient<Services.CommentsService>();
            services.AddTransient<Services.TagsService>();
            services.AddTransient<Services.UserService>();
            services.AddTransient<Services.ProfilesService>();

            services.AddScoped<Ganss.XSS.IHtmlSanitizer, Ganss.XSS.HtmlSanitizer>(x =>
            {
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });
            services.AddScoped<Services.IApiService, Services.ApiService>();
            services.AddScoped<System.Net.Http.HttpClient>();
            services.AddScoped<Services.StateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
