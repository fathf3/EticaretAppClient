using EticaretApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; // Kullanıcı giriş yapmamışsa bu yola yönlendirilecek
        options.AccessDeniedPath = "/Error/Unauthorized401"; // Yetki yoksa bu yola yönlendirilecek
    });
//builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();
builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options =>
{
   
});


var app = builder.Build();
app.UseSession();

// IHttpClientFactory kullanarak HttpClient yapılandırması

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("AccessToken");
   
    if (!string.IsNullOrEmpty(token))
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenHandler = handler.ReadJwtToken(token);
        var userRole = tokenHandler.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        
        var claims = userRole.Select(role => new Claim(ClaimTypes.Role, userRole));
        var identity = new ClaimsIdentity(claims, "Jwt");
        
        context.User.AddIdentity(identity);
    }
   
    
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        context.HttpContext.Response.Redirect("/Error/Unauthorized401");
    }else if(context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.HttpContext.Response.Redirect("/Error/Unauthorized401");
    }
});

app.UseAuthentication(); // JWT doğrulama middleware'i
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AdminArea",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
