using First_MVC_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using First_MVC_App.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(p => p.AddPolicy("corsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3000/")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthorization();
app.UseCors("corsPolicy");
app.UseAuthentication();
app.UseAuthentication();
app.MapRazorPages();

app.MapControllerRoute(
    name: "doctor",
    pattern: "doctor",
    defaults: new { controller = "Doctor", action = "FeverCheck" });

app.MapControllerRoute(
    name: "game",
    pattern: "game",
    defaults: new { controller = "GuessingGame", action = "GuessingGame" });

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();