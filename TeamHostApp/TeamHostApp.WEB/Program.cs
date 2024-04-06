using Microsoft.AspNetCore.Authentication.Cookies;
using TeamHost.Application.Extensions;
using TeamHost.Infrastructure.Extensions;
using TeamHost.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer()
    .AddPersistenceLayer(builder.Configuration);


// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//     options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//     options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();