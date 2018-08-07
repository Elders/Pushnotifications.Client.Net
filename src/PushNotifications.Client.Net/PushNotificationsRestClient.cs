﻿using System;
using PushNotifications.Api.Client.Models;
using PushNotifications.Converters;
using RestSharp;
using System.Linq;
using Newtonsoft.Json;
using Discovery.Contracts;
using PushNotifications.Contracts;
using System.Collections.Generic;

namespace PushNotifications.Api.Client
{
    public class PushNotificationsRestClient
    {
        readonly RestSharpIdentityModelClient restSharpIdentityModelClient;

        public PushNotificationsRestClient(Uri authority, string authorizationEndpointRelativePath, string clientId, string clientSecret, string scope, Uri apiAddress)
        {
            if (ReferenceEquals(authority, null) == true) throw new ArgumentNullException(nameof(authority));
            if (string.IsNullOrEmpty(authorizationEndpointRelativePath) == true) throw new ArgumentNullException(nameof(authorizationEndpointRelativePath));
            if (string.IsNullOrEmpty(clientId) == true) throw new ArgumentNullException(nameof(clientId));
            if (string.IsNullOrEmpty(clientSecret) == true) throw new ArgumentNullException(nameof(clientSecret));
            if (ReferenceEquals(apiAddress, null) == true) throw new ArgumentNullException(nameof(apiAddress));

            var authenticatorClientOptions = Authenticator.Options.UseClientCredentials(authority, clientId, clientSecret, scope, authorizationEndpointRelativePath);
            var authenticator = new Authenticator(authenticatorClientOptions);
            var clientCredentialsAuthenticator = authenticator.GetClientCredentialsAuthenticatorAsync().Result;

            var serializerSettings = SerializerFactory.DefaultSettings();
            var converters = typeof(PushNotificationsConvertersAssembly).Assembly.GetTypes()
                .Where(x => typeof(JsonConverter).IsAssignableFrom(x) && x.IsAbstract == false);

            foreach (var item in converters)
            {
                serializerSettings.Converters.Add(Activator.CreateInstance(item) as JsonConverter);
            }

            var localSerializer = new NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer.Create(serializerSettings));
            var restSharpIdentityModelClientOptions = new RestSharpIdentityModelClient.Options(apiAddress, localSerializer);

            restSharpIdentityModelClient = new RestSharpIdentityModelClient(restSharpIdentityModelClientOptions, clientCredentialsAuthenticator);
        }

        public IRestResponse SendPushNotification(SendPushNotificationModel pushNotification, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, pushNotification) == true) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/Send";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, pushNotification, authenticator);
        }

        /// <summary>
        /// Send a push notification to a given topic [Firebase]
        /// </summary>
        /// <param name="pushNotification"></param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public IRestResponse SendPushNotificationToTopic(SendPushNotificationToTopicModel pushNotification, Authenticator authenticator = null)
        {
            if (pushNotification is null) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/SendToTopic";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, pushNotification, authenticator);
        }

        public IRestResponse SubscribeForFireBase(SubscriptionForFireBase subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/Subscribe";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, subscription, authenticator);
        }

        /// <summary>
        /// Subscribe a given SubscriberId (all the devices related to an id) to a Topic 
        /// </summary>
        /// <param name="topicSubscribeModel">Include two properties, SubscriberId:string, Topic:string</param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public IRestResponse SubscribeToTopic(TopicSubscribeModel topicSubscribeModel, Authenticator authenticator = null)
        {
            if (topicSubscribeModel is null) throw new ArgumentNullException(nameof(topicSubscribeModel));

            const string resource = "Subscriptions/SubscribeToTopic";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, topicSubscribeModel, authenticator);
        }

        /// <summary>
        /// Unsubscribe a given SubscriberId (all the devices related to an id) from a Topic 
        /// </summary>
        /// <param name="topicSubscribeModel">Include two properties, SubscriberId:string, Topic:string</param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public IRestResponse UnsubscribeFromTopic(TopicSubscribeModel topicSubscribeModel, Authenticator authenticator = null)
        {
            if (topicSubscribeModel is null) throw new ArgumentNullException(nameof(topicSubscribeModel));

            const string resource = "Subscriptions/UnsubscribeFromTopic";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, topicSubscribeModel, authenticator);
        }

        public IRestResponse SubscribeForPushy(SubscriptionForPushy subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/Subscribe";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, subscription, authenticator);
        }

        public IRestResponse UnSubscribeForFireBase(SubscriptionForFireBase subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/UnSubscribe";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, subscription, authenticator);
        }

        public IRestResponse UnSubscribeForPushy(SubscriptionForPushy subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/UnSubscribe";

            return restSharpIdentityModelClient.Execute<ResponseResult>(resource, Method.POST, subscription, authenticator);
        }

        public IRestResponse GetTopicSubscribedCount(TopicSubscriptionCountModel topicSubscriptionCountModel, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, topicSubscriptionCountModel) == true) throw new ArgumentNullException(nameof(topicSubscriptionCountModel));

            const string resource = "TopicSubscriptionCount/GetTopicSubscribedCount";

            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("name", topicSubscriptionCountModel.Name);

            return restSharpIdentityModelClient.Execute<ResponseResult>(request);
        }

        public IRestResponse<ResponseResult<DiscoveryReaderResponseModel>> Discovery(Authenticator authenticator = null)
        {
            const string resource = "Discovery/Normalized";

            return restSharpIdentityModelClient.Execute<ResponseResult<DiscoveryReaderResponseModel>>(resource, Method.GET, authenticator);
        }

        public IRestResponse<ResponseResult<SubscriberTokens>> GetSubscriberTokens(SubscriberTokensModel model, Authenticator authenticator = null)
        {
            const string resource = "Subscriptions/SubscriberTokens";

            return restSharpIdentityModelClient.ExecuteGet<ResponseResult<SubscriberTokens>>(resource, model, new List<Parameter>(), authenticator);
        }
    }

    public class TopicSubscriptionCountModel
    {
        public string Name { get; set; }
    }

    public class SubscriberTokensModel
    {
        public SubscriberTokensModel(string subscriberUrn)
        {
            SubscriberUrn = subscriberUrn;
        }

        public string SubscriberUrn { get; private set; }
    }

    public class SubscriberTokens
    {
        public SubscriberTokens()
        {
            Tokens = new HashSet<SubscriptionToken>();
        }

        public SubscriberId SubscriberId { get; set; }

        public HashSet<SubscriptionToken> Tokens { get; set; }
    }
}
