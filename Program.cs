using WowRoads.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WowRoads.Models;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AzureContext>(options =>


    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
var connectionString = builder.Configuration.GetConnectionString("AzureContext");


// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<DataContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>(); builder.Services.AddDbContext<DataContext>(options =>
     options.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen();
var app = builder.Build();


CreateDbIfNotExists(app);

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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


app.Run();


static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataContext>();
            //context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}

