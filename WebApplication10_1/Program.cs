using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication10_1.Data;
using WebApplication10_1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


//
var config = builder.Configuration;
string connection = config.GetConnectionString("DataBaseLibrary");

builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connection));

var config2 = builder.Configuration;
string connection2 = config2.GetConnectionString("DataBaseUsers");
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connection2));

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

//var services = app.Services.CreateScope().ServiceProvider;

//var context = services.GetRequiredService<LibraryContext>();
//SampleData.Initialize1(context);

//var services2 = app.Services.CreateScope().ServiceProvider;
//var context2 = services2.GetRequiredService<UserContext>();
//SampleData.Initialize2(context2);

app.Run();
