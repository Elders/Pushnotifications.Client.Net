using System;
using PushNotifications.Api.Client.Models;
using RestSharp;
using Discovery.Contracts;

namespace PushNotifications.Api.Client
{
    public partial class PushNotificationsRestClient
    {
        Options options;
        Authenticator authenticator;

        public PushNotificationsRestClient(Options options, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, options)) throw new ArgumentNullException(nameof(options));
            this.options = options;

            this.authenticator = authenticator;
        }

        public sealed class Options
        {
            public Options(Uri apiAddress)
            {
                ApiAddress = apiAddress;
                JsonSerializer = NewtonsoftJsonSerializer.Default();
            }

            public Uri ApiAddress { get; private set; }
            public IJsonSerializer JsonSerializer { get; private set; }
        }

        public IRestResponse SendPushNotification(SendPushNotificationModel pushNotification, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, pushNotification) == true) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/Send";

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(pushNotification);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
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

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(pushNotification);

            var response = CreateRestClient().Execute<ResponseResult>(request);
            return response;
        }

        public IRestResponse SubscribeForFireBase(SubscriptionForFireBase subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/Subscribe";

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(subscription);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
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

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(topicSubscribeModel);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
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

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(topicSubscribeModel);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
        }

        public IRestResponse SubscribeForPushy(SubscriptionForPushy subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/Subscribe";

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(subscription);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
        }

        public IRestResponse UnSubscribeForFireBase(SubscriptionForFireBase subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/UnSubscribe";

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(subscription);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
        }

        public IRestResponse UnSubscribeForPushy(SubscriptionForPushy subscription, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, subscription) == true) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/UnSubscribe";

            var request = CreateRestRequest(resource, Method.POST, authenticator)
                .AddJsonBody(subscription);

            var response = CreateRestClient().Execute<ResponseResult>(request);

            return response;
        }

        public IRestResponse<ResponseResult<StatCount>> GetTopicSubscribedCount(TopicSubscriptionCountModel topicSubscriptionCountModel, Authenticator authenticator = null)
        {
            if (ReferenceEquals(null, topicSubscriptionCountModel) == true) throw new ArgumentNullException(nameof(topicSubscriptionCountModel));

            const string resource = "TopicSubscriptionCount/GetTopicSubscribedCount";

            var request = CreateRestRequest(resource, Method.GET, authenticator);
            request.AddQueryParameter("name", topicSubscriptionCountModel.Name);

            var response = CreateRestClient().Execute<ResponseResult<StatCount>>(request);

            return response;
        }

        public IRestResponse<ResponseResult<DiscoveryReaderResponseModel>> Discovery(Authenticator authenticator = null)
        {
            const string resource = "Discovery/Normalized";

            var request = CreateRestRequest(resource, Method.GET, authenticator);

            var response = CreateRestClient().Execute<ResponseResult<DiscoveryReaderResponseModel>>(request);

            return response;
        }

        public IRestResponse<ResponseResult<SubscriberTokens>> GetSubscriberTokens(SubscriberTokensModel model, Authenticator authenticator = null)
        {
            const string resource = "Subscriptions/SubscriberTokens";

            var request = CreateRestRequest(resource, Method.GET, authenticator);
            request.AddQueryParameter("subscriberUrn", model.SubscriberUrn);

            var response = CreateRestClient().Execute<ResponseResult<SubscriberTokens>>(request);

            return response;
        }
    }
}
