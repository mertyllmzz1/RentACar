using Business.Abstract;
using Business.AutoMapping;
using Business.Concrete;
using DataAccess;
using DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<RentContext>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICategoryService, CategoriesService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddAutoMapper(typeof(AutoProfile));
//builder.Services.UserManager();
builder.Services.AddControllersWithViews();
#region User Login için Gerekli Olan Ayarlamalar.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/User";
    x.LogoutPath = "/admin/Cikis";
    x.AccessDeniedPath = "/YetkisizGiris";
});
#endregion
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
    x.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
});
//app.MapGet("/", () => "Hello World!");

app.Run();
