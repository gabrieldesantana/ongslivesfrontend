using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLivesFront.MVC.Helpers;
using OngsLivesFront.MVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


///
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();    

builder.Services.AddSession(x =>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});
///
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<OngLivesContext>();

builder.Services.AddDbContext<OngLivesContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));});

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

app.UseCors(
    options => options
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
