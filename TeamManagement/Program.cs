using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamManagement.Areas.Identity.Data;
using TeamManagement.Data;
using TeamManagement.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TeamManagementContextConnection");;

builder.Services.AddDbContext<TeamManagementContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<TeamManagementUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TeamManagementContext>();;
//builder.ConfigureServices((context, services) =>
//{
//    builder.Services.AddDbContext<TeamManagementContext>(options =>
//        options.UseSqlServer(
//            context.Configuration.GetConnectionString("TeamManagementContextConnection")));
//});

//    builder.Services.AddDefaultIdentity<TeamManagementUser>(options => options.SignIn.RequireConfirmedAccount = true)
//        .AddEntityFrameworkStores<TeamManagementContext>();


    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
    app.UseAuthentication(); ;

    app.UseAuthorization();

    //app.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=Home}/{action=Index}/{id?}");

    //app.Run();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
    });
    app.Run();
