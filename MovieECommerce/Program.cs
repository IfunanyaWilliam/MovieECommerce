using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Repositories;
using MovieECommerce.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add the DbContext to the builder
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


//Add the services to the builder for Cloudinary by mapping the CloudinaryConfiguration class to the appsettings.json file
builder.Services.Configure<CloudinaryConfiguration>(builder.Configuration.GetSection("Cloudinary"));

builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add service for Razorpages
builder.Services.AddRazorPages(); 

//add automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
