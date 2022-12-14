using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Magazin.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Proiect_MagazinContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MagazinContext") ?? throw new InvalidOperationException("Connection string 'Proiect_MagazinContext' not found.")));
builder.Services.AddDbContext<ShopIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_MagazinContext") ?? throw new InvalidOperationException("Connectionstring 'Proiect_MagazinContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
