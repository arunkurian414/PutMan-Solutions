using BLL.LogicServices;
using BOL.Models;
using DAL.DataServices;
using DAL.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ICategoryDataServices, CategoryDataServices>();
        builder.Services.AddScoped<ICategoryLogicServices, CategoryLogicServices>();
        builder.Services.AddDbContext<SQLDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDBConnection")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 5;
            options.Password.RequiredUniqueChars = 3;
        }).AddEntityFrameworkStores<SQLDBContext>();

        builder.Services.AddMvc(opt =>       // The default login path is /Account/Login. To customize it use ConfigureApplicationCookie and set
                                             // the default path
        {
            var authPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(authPolicy));
        }).AddXmlSerializerFormatters();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Home/index"; // Customize the path to your login action
        });


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
            pattern: "{controller=Account}/{action=SupplierProfile}/{id?}");

        app.Run();
    }
}