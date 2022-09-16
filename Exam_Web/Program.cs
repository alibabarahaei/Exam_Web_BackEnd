using Exam_Web.Config;
using Exam_Web.Config.Extensions;
using Exam_Web.CoreLayer.Services.Exam;
using Exam_Web.CoreLayer.Services.Users;
using Exam_Web.DataLayer.Context;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersianTranslation.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var appSettings = new AppSettings();
appSettings.Secret = "reds";

builder.Services.AddOurAuthentication(appSettings);




builder.Services.AddIdentity<UserIdentity, IdentityRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        
    })
    .AddEntityFrameworkStores<ExamContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IExamService, ExamService>();


builder.Services.AddDbContext<ExamContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "62913900782-8ts3r1lkfl1tj8hfehufsvn6mvuapomj.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
