using BlazorApplication.Data;
using BlazorApplication.Repo;
using BlazorApplication.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<FirstTaskContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FirstTask")));
builder.Services.AddScoped<ICustomerTableRepo, CustomerTableRepo>();
builder.Services.AddScoped<IProductTablePrpo, ProductTablePrpo>();
builder.Services.AddScoped<CustomerTableService>();
builder.Services.AddScoped<ProductTableService>();
builder.Services.AddApplicationInsightsTelemetry();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
