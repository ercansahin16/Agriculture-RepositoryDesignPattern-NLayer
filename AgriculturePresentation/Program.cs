using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



#region Eklemelerim




builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<IServiceDal, EFServiceDal>();

builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EFTeamDal>();

builder.Services.AddScoped<INewsService, NewsManager>();
builder.Services.AddScoped<INewsDal, EFNewsDal>();

builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IImageDal, EFImageDal>();

builder.Services.AddScoped<IAddressSevices, AddressManager>();
builder.Services.AddScoped<IAdressDal, EFAddressDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EFContactDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EFAboutDal>();

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EFAdminDal>();


builder.Services.AddDbContext<AgricultureContext>();



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
   .AddEntityFrameworkStores<AgricultureContext>() // IdentityBuilder döner
    .AddDefaultTokenProviders(); //register için builder kodu








//Burada Identity paketlerinin kurulumundan sonra gerekli olan autorize kodlarýdýr
builder.Services.AddMvc(config =>
{

   var policy = new AuthorizationPolicyBuilder()
   .RequireAuthenticatedUser()
   .Build();
   config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(
   CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(x =>
   {
      x.LoginPath = "/Login/Index/";
   });
   

//Autorize bitiþ














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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
