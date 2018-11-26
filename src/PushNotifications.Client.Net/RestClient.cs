using System;
using PushNotifications.Client.Net.Infrastructure;
using RestSharp;
using RestSharp.Deserializers;

namespace PushNotifications.Client.Net
{
    public sealed partial class PushNotificationsClient
    {
        /// <summary>
        /// Creates a new <see cref="IRestClient"/> with <see cref="RestSharp.Deserializers.IDeserializer" /> handlers.
        /// </summary>
        /// <returns></returns>
        IRestClient CreateRestClient(IDeserializer deserializer)
        {
            var client = new RestClient(options.ApiAddress);

            client.ClearHandlers();

            client.AddHandler("application/json", deserializer);
            client.AddHandler("text/json", deserializer);
            client.AddHandler("text/x-json", deserializer);
            client.AddHandler("text/javascript", deserializer);
            client.AddHandler("*+json", deserializer);

            return client;
        }

        IRestClient CreateRestClient()
        {
            return CreateRestClient(options.JsonSerializer);
        }

        IRestRequest CreateRestRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = options.JsonSerializer;
            request.AddAuthorizationBearerHeader(GetAuthenticator());

            return request;
        }

        Authenticator GetAuthenticator()
        {
            if (ReferenceEquals(null, authenticator))
                throw new ArgumentNullException(nameof(authenticator), "Not a valid authenticator is specified. You can initialize a default Authenticator on Client.ctor(...) or specify explicitly the Authenticator with each call. On of the two is mandatory.");

            if (authenticator.ExpiresIn < 120)
                authenticator = authenticator.GetClientCredentialsAuthenticatorAsync().Result;

            return authenticator;
        }
    }
}
