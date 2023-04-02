using webapplication.dataaccess.Contexts;
using webapplication.entity.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/giris-yap";
    options.LogoutPath = "/cikis-yap";
    options.Cookie.Name = "auth_cookie";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.Cookie.HttpOnly = true;
});
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/giris-yap";
        options.LogoutPath = "/cikis-yap";
        options.Cookie.Name = "auth_cookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
        options.Cookie.HttpOnly = true;
    }).AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];
        options.CallbackPath = new PathString("/auth/google-callback");
    });
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse =
        r =>
        {
            string path = r.File.PhysicalPath;
            if (path.EndsWith(".css") || path.EndsWith(".js") || path.EndsWith(".gif") || path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".svg") || path.EndsWith(".ttf"))
            {
                TimeSpan maxAge = new TimeSpan(7, 0, 0, 0);
                r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
            }
            // else{
            //     if(!r.Context.User.Identity.IsAuthenticated){
            //       r.Context.Response.Redirect("/auth/accessdenied");
            //     }
            // }
        }
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "profilim/ayarlar",
        pattern: "profilim/ayarlar",
        defaults: new { controller = "Account", action = "Settings" }
    );
    endpoints.MapControllerRoute(
        name: "profilim/duzenle",
        pattern: "profilim/duzenle",
        defaults: new { controller = "Account", action = "EditProfile" }
    );
    endpoints.MapControllerRoute(
        name: "profilim",
        pattern: "profilim",
        defaults: new { controller = "Account", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "kayit-ol",
        pattern: "kayit-ol",
        defaults: new { controller = "Auth", action = "Register" }
    );
    endpoints.MapControllerRoute(
        name: "GoogleLogin",
        pattern: "signin-google",
        defaults: new { controller = "Auth", action = "GoogleLogin" });
    endpoints.MapControllerRoute(
        name: "cikis-yap",
        pattern: "cikis-yap",
        defaults: new { controller = "Auth", action = "Logout" }
    );
    endpoints.MapControllerRoute(
        name: "giris-yap",
        pattern: "giris-yap",
        defaults: new { controller = "Auth", action = "Login" }
    );
    endpoints.MapControllerRoute(
        name: "/",
        pattern: "/",
        defaults: new { controller = "Home", action = "Index" }
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}"
    );
});
app.Run();
