using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PushNotifications.Client.Net
{
    public static class PushNotificationserviceCollectionExtensioins
    {
        public static IServiceCollection AddPushNotifications(this IServiceCollection container, IConfiguration configuration)
        {
            var authority = new Uri(configuration["push_notifications_authority"]);
            var clientId = configuration["push_notifications_client_id"];
            var clientSecret = configuration["push_notifications_client_secret"];
            var scope = configuration["push_notifications_scope"];
            var authenticatorOptions = Authenticator.Options.UseClientCredentials(authority, clientId, clientSecret, scope);
            var authenticator = new Authenticator(authenticatorOptions);

            var clientOptions = new PushNotificationsClient.Options(new Uri(configuration["push_notifications_base_url"]));
            container.AddSingleton(new PushNotificationsClient(clientOptions, authenticator));

            return container;
        }
    }
}
