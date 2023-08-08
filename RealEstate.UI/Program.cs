using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.BLL.Abstract;
using RealEstate.BLL.Concrete;
using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.EntityFramework;
using RealEstate.Entities.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSession();




builder.Services.AddScoped<IAgentService, AgentManager>();
builder.Services.AddScoped<IAgentDal,EfAgentDal>();

builder.Services.AddScoped<IPropertyService, PropertyManager>();
builder.Services.AddScoped<IPropertyDal, EfPropertyDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IPropertyStatusService, PropertyStatusManager>();
builder.Services.AddScoped<IPropertyStatusDal, EfPropertyStatusDal>();

builder.Services.AddScoped<IPropertyPhotoService, PropertyPhotoManager>();
builder.Services.AddScoped<IPropertyPhotoDAL, EFPropertyPhotoDAL>();

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



app.MapControllerRoute(name: "default",
					   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();
app.UseSession();

app.Run();

