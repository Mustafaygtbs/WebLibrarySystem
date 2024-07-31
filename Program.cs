using Microsoft.EntityFrameworkCore;
using WebLibrarySystem.Models;
using WebLibrarySystem.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDContext>(options=>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDContext>().AddDefaultTokenProviders();
// razor sayfalarını kullanabilmek için eklemeliyiz.
builder.Services.AddRazorPages();



// _kitapTuruRepository nesnesi => dependency injection 
// _kitapRepository nesnesi => dependency injection
// _kiralamaRepository nesnesi => dependency injection
// yeni repository s�n�f� olu�turuldu�unda burada servislere eklenmelidir.
builder.Services.AddScoped<IKitapTuruRepository ,KitapTuruRepository>();
builder.Services.AddScoped<IKitapRepository ,KitapRepository>();
builder.Services.AddScoped<IKiralamaRepository , KiralamaRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();




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

// razor sayfalarını kullanabilmek için eklemeliyiz.
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
