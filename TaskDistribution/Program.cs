using TaskDistribution.Data.Modals;
using TaskDistribution.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
//    x =>
//    {
//        //x.Cookie.IsEssential = true;
//        x.LoginPath = "/Login/Index/";
//        x.Cookie.HttpOnly = true;
//        //x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//        //x.Cookie.SameSite = SameSiteMode.None;
//        //x.Cookie.Name = "Cookie";
//        //x.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
//    });
//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();

//    config.Filters.Add(new AuthorizeFilter(policy));
//});


//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("Software Analyst", policy => policy.RequireClaim(ClaimTypes.Role));
//});
builder.Services.AddScoped<TaskDistributionContext>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskDifficultTypeRepository, TaskDifficultTypeRepository>();
builder.Services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Login}/{action=Index}/{id?}"); 
    });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();
