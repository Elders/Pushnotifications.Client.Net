using RestSharp;
using RestSharp.Deserializers;
using System;

namespace PushNotifications.Api.Client
{
    public sealed partial class PushNotificationsRestClient
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

        IRestRequest CreateRestRequest(string resource, Method method, Authenticator inlineAuthenticator = null)
        {
            var request = new RestRequest(resource, method);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = options.JsonSerializer;
            request.AddAuthorizationBearerHeader(Eval(inlineAuthenticator));
            return request;
        }

        Authenticator Eval(Authenticator inlineAuthenticator)
        {
            if (ReferenceEquals(null, authenticator) && ReferenceEquals(null, inlineAuthenticator))
                throw new ArgumentNullException(nameof(authenticator), "Not a valid authenticator is specified. You can initialize a default Authenticator on Client.ctor(...) or specify explicitly the Authenticator with each call. On of the two is mandatory.");

            if (ReferenceEquals(null, inlineAuthenticator) == false)
                return inlineAuthenticator;

            if (authenticator.ExpiresIn < 120)
            {
                if (authenticator.TheOptions.AuthenticationFlow == Authenticator.AuthenticationFlow.ClientCredentials)
                    authenticator = authenticator.GetClientCredentialsAuthenticatorAsync().Result;
                else if (authenticator.TheOptions.AuthenticationFlow == Authenticator.AuthenticationFlow.ResourceOwnerPassword)
                    authenticator = authenticator.GetResourceOwnerAuthenticatorAsync().Result;
                else
                    throw new InvalidOperationException($"Unsupported {nameof(Authenticator.AuthenticationFlow)} value '{authenticator.TheOptions.AuthenticationFlow}'");
            }

            return authenticator;
        }
    }
}
