using Microsoft.EntityFrameworkCore;
using RealEstate.BLL.Abstract;
using RealEstate.BLL.Concrete;
using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.EntityFramework;
using RealEstate.Entities.Entities;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .WriteTo.Console()
  .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
  .WriteTo.File("logs/log.txt")
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


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

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();

builder.Services.AddScoped<ITestimonialService,TestimonialManager >();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<ISehirDAL, EFSehirDAL>();
builder.Services.AddScoped<ISehirService, SehirManager>();

builder.Services.AddScoped<IIlceDAL, EFIlceDAL>();
builder.Services.AddScoped<IIlceService, IlceManager>();

builder.Services.AddScoped<IMahalleDAL, EFMahalleDAL>();
builder.Services.AddScoped<IMahalleService, MahalleManager>();

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

