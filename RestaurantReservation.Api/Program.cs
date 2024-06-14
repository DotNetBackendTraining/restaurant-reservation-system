using RestaurantReservation.Api.Auth.Common;
using RestaurantReservation.App.Configuration;
using RestaurantReservation.App.Configuration.Db;

var builder = WebApplication.CreateBuilder(args);

// Add settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson();
builder.Services.AddJwtAuthentication(builder.Configuration);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();