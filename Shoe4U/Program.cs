using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoe4U.Data;
using Shoe4U.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Shoe4UDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedEmail = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Shoe4UDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

MigrateDatabase();

app.Run();

return;

void MigrateDatabase()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Shoe4UDbContext>();
    context.Database.Migrate();
}