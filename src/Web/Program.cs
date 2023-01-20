using DirectId_EOD.Api.Middleware;
using Persistance;
using Application;
using Implementation;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddImplementation();
builder.Services.AddPersistance();
builder.Services.AddShared();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHsts();
}

DataSeeder.SeedAccountData();
//.SeedData();

app.UseCustomExceptionHandler();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
