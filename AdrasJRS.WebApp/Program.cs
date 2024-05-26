using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AdrasJRS.Data.DataContext;
using AdrasJRS.Data.Entities;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using AdrasJRS.Localizers;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    factory.Create(null);
})
.AddViewLocalization().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IStringLocalizer, EFStringLocalizer>();

builder.Services.AddSingleton<IStringLocalizerFactory>(new EFStringLocalizerFactory());

var connectionString = builder.Configuration.GetConnectionString("AdrasJRSContextConnection");

builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddTransient<DataDbContext>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<DataDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();

builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "AdrasJRS";
    options.IdleTimeout = new TimeSpan(0, 30, 0);
    //options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    //options.LoginPath = "/Account/Login";
    //options.LoginPath = "/login";
});

builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ru"),
    new CultureInfo("uz"),
    new CultureInfo("de"),
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); ;

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();
