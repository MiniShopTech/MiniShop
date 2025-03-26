using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniShop.Models.Data;
using MiniShop.Models.Entities;
using MiniShop.Services.Mapping;
using MiniShop.Web.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41))
    )
);
new ServiceRepoMapping().Mapping(builder);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(origin => true)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
