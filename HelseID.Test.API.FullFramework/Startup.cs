using System;
using System.Configuration;
using System.Threading.Tasks;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HelseID.Test.API.FullFramework.Startup))]

namespace HelseID.Test.API.FullFramework
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authority = ConfigurationManager.AppSettings["authority"];
            var requiredScopes = ConfigurationManager.AppSettings["requiredscopes"].Split(',');

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = authority,
                RequiredScopes = requiredScopes, //new [] { "helseid.test.api.fullframework" },   
                ClientId = "nhn_test_api",
                ClientSecret = "R44ICBG5av3XagvBCX145AumJ9MGDX6KgQ8fOztYuLjrpRsXV7qrtTBrSNqmfZR3",
            });
        }
    }
}
