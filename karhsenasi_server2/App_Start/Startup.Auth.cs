using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using karhsenasi_server2.Models;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Infrastructure;
using karhsenasi_server2.Providers;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;

namespace karhsenasi_server2
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);


            OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenFormat = new TicketDataFormat(app.CreateDataProtector(
                   typeof(OAuthAuthorizationServerMiddleware).Namespace,
                   "Access_Token", "v1")),
                RefreshTokenFormat = new TicketDataFormat(app.CreateDataProtector(
                    typeof(OAuthAuthorizationServerMiddleware).Namespace,
                    "Refresh_Token", "v1")),
                AccessTokenProvider = new AuthenticationTokenProvider(),
                RefreshTokenProvider = new AuthenticationTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            var OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            OAuthBearerOptions.AccessTokenFormat = OAuthOptions.AccessTokenFormat;
            OAuthBearerOptions.AccessTokenProvider = OAuthOptions.AccessTokenProvider;
            OAuthBearerOptions.AuthenticationMode = OAuthOptions.AuthenticationMode;
            OAuthBearerOptions.AuthenticationType = OAuthOptions.AuthenticationType;
            OAuthBearerOptions.Description = OAuthOptions.Description;

 //           OAuthBearerOptions.Provider = new CustomBearerAuthenticationProvider();
            OAuthBearerOptions.SystemClock = OAuthOptions.SystemClock;

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}