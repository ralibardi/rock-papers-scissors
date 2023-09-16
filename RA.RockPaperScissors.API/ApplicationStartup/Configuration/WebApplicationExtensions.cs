namespace RA.RockPaperScissors.API.ApplicationStartup.Configuration;

public static class WebApplicationExtensions
{
    public static void ConfigureWebApplication(this IApplicationBuilder app, IWebHostEnvironment environment, IConfiguration configuration)
    {
        app.UseCookiePolicy();

        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
            app.UseForwardedHeaders();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseForwardedHeaders();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });

        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSpa(spa => spa.Options.SourcePath = "ClientApp");
    }
}