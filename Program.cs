using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmpregaSENAI.Areas.Identity.Data;
using EmpregaSENAI.Models;
using EmpregaSENAI.Core;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppContConnection") ?? throw new InvalidOperationException("Connection string 'AppContConnection' not found.");

builder.Services.AddDbContext<AppCont>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppCont>()
    .AddDefaultUI().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Authorization

AddAuthorizationPolicies(builder.Services);

#endregion

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

void AddAuthorizationPolicies(IServiceCollection services)
{
    /*
    services.AddAuthorization(options =>
    {
        options.AddPolicy("EMPRESA", policy => policy.RequireClaim("empresa"));
    });
    */

    services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.Empresa, policy => policy.RequireRole("Empresa"));
        options.AddPolicy(Constants.Policies.Aluno, policy => policy.RequireRole("Aluno"));
    });

    services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequiredAdmin, policy => policy.RequireRole("Adm"));
    });
}