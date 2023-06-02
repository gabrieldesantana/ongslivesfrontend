using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRegisterServices();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<OngLivesContext>();

builder.Services.AddDbContext<OngLivesContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));});

builder.Services.AddCors(options => { options.AddPolicy("OngsLivesCorsPolicy", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });

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

//
app.UseSession();
//

//app.UseCors(
//    options => options
//    .AllowAnyOrigin()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
