using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmpregaSENAI.Areas.Identity.Data;
using EmpregaSENAI.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppContConnection") ?? throw new InvalidOperationException("Connection string 'AppContConnection' not found.");

builder.Services.AddDbContext<AppCont>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<AppCont>()
    .AddDefaultUI().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
    
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
