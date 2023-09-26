using SWT.MVC.Web.Service;
using SWT.MVC.Web.Service.Contracts;
using SWT.MVC.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponContract, CouponService>();

builder.Services.AddTransient<IBaseContract<Object,Object>, BaseService<Object,Object>>();
builder.Services.AddTransient<ICouponContract, CouponService>();

var app = builder.Build();

Configuration.CouponApiUrl = builder.Configuration["ServiceUrls:CouponAPI"];
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
