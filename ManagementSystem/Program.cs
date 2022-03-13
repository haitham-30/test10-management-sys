using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ManagementSystem.Areas.Identity.Data;
using ManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ManagementSystemContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<ManagementSystemUser>(options =>
{

    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

})
 .AddRoles<IdentityRole>()
 .AddDefaultUI()
 .AddEntityFrameworkStores<ManagementSystemContext>()
 .AddDefaultTokenProviders();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ManagementSystemContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();



//using (IServiceScope? scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//    try
//    {
//        var context = services.GetRequiredService<EmployeeSystemAppContext>();
//        var userManager = services.GetRequiredService<UserManager<EmployeeSystemAppUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        await Seeds.SeedRoles(userManager, roleManager);
//        await Seeds.SeedUser(userManager, roleManager);

//    }
//    catch (Exception ex)
//    {
//        var logger = loggerFactory.CreateLogger<Program>();
//        logger.LogError(ex, "An error occurred seeding the DB.");
//    }



//}


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
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();

});

app.Run();
