using ABCBANKWEBAPP2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CommonDBContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("ABCDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=Transactions}/{action=Index}/{id?}");
     // pattern: "{controller=Transactions}/{action=CreateOrEdit}/{id?}");
    pattern: "{controller=Home}/{action=Index}/{id?}");
  //  pattern: "{controller=Contacts}/{action=CreateOrEditContact}/{id?}");


//app.MapControllerRoute(
//    name: "MainHome",
//    pattern: "{controller=MainHome}/{action=Index}/{id?}");


app.Run();
