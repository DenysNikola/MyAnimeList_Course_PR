using MyAnimeList.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AnimeDbService>();

builder.Services.AddDbContext<AnimeDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = new[] { new CultureInfo("en-US") },
    SupportedUICultures = new[] { new CultureInfo("en-US") }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Anime}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "animeDetails",
        pattern: "Anime/AnimeDetails/{id?}",
        defaults: new { controller = "Anime", action = "AnimeDetails" });
    endpoints.MapControllerRoute(
        name: "animeEdit",
        pattern: "Anime/Edit/{id?}",
        defaults: new { controller = "Anime", action = "Edit" });
    endpoints.MapControllerRoute(
        name: "userTable",
        pattern: "User",
        defaults: new { controller = "User", action = "UserTable" });
    endpoints.MapControllerRoute(
        name: "userDetails",
        pattern: "AnimeInfo/userDetails/{id?}",
        defaults: new { controller = "AnimeInfo", action = "userDetails" });
});

app.Run();
