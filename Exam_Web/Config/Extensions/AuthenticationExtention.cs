using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
namespace Exam_Web.Config.Extensions
{
    public static class AuthenticationExtention
    {


        public static IServiceCollection AddOurAuthentication(this IServiceCollection services,
            AppSettings appSettings)
        {
            
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
            return services;
        }
    }
}
