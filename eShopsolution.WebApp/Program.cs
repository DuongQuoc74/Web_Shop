using eShopSolution.ApiIntegration.Services;
using eShopsolution.WebApp.LocalizationResources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using eShopSolution.ViewModels.System.Users;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Localization;
using System;
using Microsoft.Extensions.Hosting;

var Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
//ConfigureService in Startup
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
//Mutiple Language
var cultures = new[]
{
                new CultureInfo("en"),
                new CultureInfo("vi"),
            };
// Mutiple Language End
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
             // Mutiple Language
             .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
             {
                 // When using all the culture providers, the localization process will
                 // check all available culture providers in order to detect the request culture.
                 // If the request culture is found it will stop checking and do localization accordingly.
                 // If the request culture is not found it will check the next provider by order.
                 // If no culture is detected the default culture will be used.

                 // Checking order for request culture:
                 // 1) RouteSegmentCultureProvider
                 //      e.g. http://localhost:1234/tr
                 // 2) QueryStringCultureProvider
                 //      e.g. http://localhost:1234/?culture=tr
                 // 3) CookieCultureProvider
                 //      Determines the culture information for a request via the value of a cookie.
                 // 4) AcceptedLanguageHeaderRequestCultureProvider
                 //      Determines the culture information for a request via the value of the Accept-Language header.
                 //      See the browsers language settings

                 // Uncomment and set to true to use only route culture provider
                 ops.UseAllCultureProviders = false;
                 ops.ResourcesPath = "LocalizationResources";
                 ops.RequestLocalizationOptions = o =>
                 {
                     o.SupportedCultures = cultures;
                     o.SupportedUICultures = cultures;
                     o.DefaultRequestCulture = new RequestCulture("vi");
                 };
             });
//Mutiple Language End

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LogoutPath = "/Account/Login";
        options.AccessDeniedPath = "/";
    });
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//token
builder.Services.AddTransient<ISildeAipClient, SlideApiClient>();
builder.Services.AddTransient<IProductApiClient, ProductApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();

//Configure method in Startup
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseRequestLocalization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Product Category En",
        pattern: "{culture=vi}/categories/{id}",
        new
        {
            controller = "Product",
            action = "Category"
        });

    endpoints.MapControllerRoute(
        name: "Product Category Vn",
        pattern: "{culture}/danh-muc/{id}",
            new
            {
                controller = "Product",
                action = "Category"
            });

    endpoints.MapControllerRoute(
        name: "Product Detail En",
        pattern: "{culture}/products/{id}",
            new
            {
                controller = "Product",
                action = "Detail"
            });
    endpoints.MapControllerRoute(
        name: "Product Detail Vn",
        pattern: "{culture}/san-pham/{id}", new
        {
            controller = "Product",
            action = "Detail"
        });


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");
});

app.Run();