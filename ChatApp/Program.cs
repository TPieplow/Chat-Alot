using ChatApp.Configurations;
using Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.MapHub<ChatHub>("/chathub");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
