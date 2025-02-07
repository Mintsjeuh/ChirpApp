using ChirpApp.Client.Pages;
using ChirpApp.Components;
using ChirpApp.Data;
using ChirpApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using ChirpApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add controllers
builder.Services.AddControllers();

builder.Services.AddRazorPages();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IAlbumApiService, AlbumApiService>();
builder.Services.AddScoped<IAlbumFilterService, AlbumFilterService>();

// Configure HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7217/")
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ChirpApp.Client._Imports).Assembly);

app.MapControllers();

app.Run();
