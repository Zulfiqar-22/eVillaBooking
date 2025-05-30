using eVillaBooking.Application.Common.Interfaces;
using eVillaBooking.Domain.Entity;
using eVillaBooking.Infrastructure.Data;
using eVillaBooking.Infrastructure.Repositroy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
	string Connectionstring = builder.Configuration.GetValue<string>("MyConnectionStrings:Dbconnection")!;

	opt.UseSqlServer(Connectionstring);
}
);
//builder.Services.AddScoped<IVillaRepository, VillaRepository>();
//builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

//builder.Services.Configure<IdentityOptions>(opt =>
//{
//	opt.Password.RequiredLength = 14;
//});

//builder.Services.ConfigureApplicationCookie(opt=>
//{
//	opt.
//})


builder.Services.AddScoped<Iunitofwork, UnitofWork>();


var app = builder.Build();
StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("Stripe:Secretkey");

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
