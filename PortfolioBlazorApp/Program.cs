using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ganss.XSS;
using Polly.Extensions.Http;
using Polly;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;

namespace PortfolioBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = builder.Configuration["Endpoint Base Address"];
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            //builder.Services.AddScoped<ProjectApiService>();

            builder.Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });

            builder.Services.AddScoped<Auth0AuthorizationMessageHandler>();
            builder.Services.AddHttpClient<ProjectApiService>(b => b.BaseAddress = new Uri(baseAddress))
                .AddHttpMessageHandler<Auth0AuthorizationMessageHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
                .AddPolicyHandler(GetRetryPolicy());

            builder.Services.AddHttpClient<PublicProjectApiService>(b => b.BaseAddress = new Uri(baseAddress))
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
                .AddPolicyHandler(GetRetryPolicy());

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("https://schemas.dev-k1t7wt86.com/roles");
            });

            await builder.Build().RunAsync();
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            Random jitterer = new Random();
            var retryWithJitterPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6,    // exponential back-off plus some jitter
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                  + TimeSpan.FromMilliseconds(jitterer.Next(0, 100))
                );
            return retryWithJitterPolicy;
        }
    }

    public class Auth0AuthorizationMessageHandler : AuthorizationMessageHandler 
    { 
        public Auth0AuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager, IConfiguration config) 
            : base(provider, navigationManager) 
        {
            this.ConfigureHandler(authorizedUrls: new[] { config["Endpoint Base Address"], "https://localhost:5001", "https://wyattbrown23.github.io/Portfolio/", "https://myportfolio-wyattb.herokuapp.com/", "https://wyatt-portfolio-api/" });
        }
    }
}
