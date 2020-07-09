using System;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PushNotifications.Client.Net
{
    public static class PushNotificationserviceCollectionExtensioins
    {
        public static IServiceCollection AddPushNotifications(this IServiceCollection services, IConfiguration configuration)
        {

            Uri identityAndAccesspiAddress = new Uri(configuration["pushnotifications:address"]);
            string identityAndAccessAuthority = configuration["pushnotifications:auth:authority"];
            string clientId = configuration["pushnotifications:auth:clientid"];
            string clientSecret = configuration["pushnotifications:auth:clientsecret"];
            string clientScope = configuration["pushnotifications:auth:clientscope"];

            services
                .AddHttpClient<PushNotificationsHttpClient>(client => client.BaseAddress = identityAndAccesspiAddress)
                .AddClientAccessTokenHandler("pn_idsrv");

            services
                .AddAccessTokenManagement(options =>
                {
                    options.Client.Clients.Add("pn_idsrv", new ClientCredentialsTokenRequest()
                    {
                        Address = $"{identityAndAccessAuthority}/connect/token",
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                        Scope = clientScope
                    });
                });

            return services;
            //var authority = new Uri(configuration["push_notifications_authority"]);
            //var clientId = configuration["push_notifications_client_id"];
            //var clientSecret = configuration["push_notifications_client_secret"];
            //var scope = configuration["push_notifications_scope"];
            //var authenticatorOptions = Authenticator.Options.UseClientCredentials(authority, clientId, clientSecret, scope);
            //var authenticator = new Authenticator(authenticatorOptions);

            //var clientOptions = new PushNotificationsClient.Options(new Uri(configuration["push_notifications_base_url"]));
            //services.AddSingleton(new PushNotificationsClient(clientOptions, authenticator));

            //return services;
        }
    }
}
