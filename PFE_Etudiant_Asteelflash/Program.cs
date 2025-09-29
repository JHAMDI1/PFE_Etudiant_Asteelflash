using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Infrastucture.Extension;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.DbInitializer;
using PFE_Etudiant_Asteelflash.Application.Common.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PFE_Etudiant_Asteelflash.Mapping.Fnc;
using PFE_Etudiant_Asteelflash.Mapping;
using PFE_Etudiant_Asteelflash.Domain.Not_Mapped_Entities;
using PFE_Etudiant_Asteelflash.Infrastucture.Hubs;
using PFE_Etudiant_Asteelflash.Infrastucture.External;

var builder = WebApplication.CreateBuilder(args);

// add DBContext with explicit SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DeafaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddServiceRegistration();

// Enregistre automatiquement tous les profils AutoMapper présents dans l'assembly (Mapping/*)
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configuration des options d'email
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Ajout de SignalR pour les notifications temps réel
builder.Services.AddSignalR();

// Enregistrement du service de notification
builder.Services.AddScoped<INotificationService, NotificationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Mapper le hub SignalR
app.MapHub<NotificationHub>("/notifHub");

// Initialiser la base de données avec des données de test
await DbInitializer.InitializeAsync(app);

app.Run();
