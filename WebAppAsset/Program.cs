using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppAsset.Data;
using WebAppAsset.Models;

var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr") ?? throw new InvalidOperationException("Connection string 'ConStr' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConStr));
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
//Add Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();//1
app.UseAuthorization();//2
//Add Razor Pages pipeline
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
