var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute
    (name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}");

app.Run();
