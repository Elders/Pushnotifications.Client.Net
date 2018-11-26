using System;
using RestSharp;

namespace PushNotifications.Client.Net
{
    public partial class PushNotificationsClient
    {
        public ResponseResult SendPushNotification(SendPushNotificationModel pushNotification)
        {
            if (pushNotification is null) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/Send";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(pushNotification);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        /// <summary>
        /// Send a push notification to a given topic [Firebase]
        /// </summary>
        /// <param name="pushNotification"></param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public ResponseResult SendPushNotificationToTopic(SendPushNotificationToTopicModel pushNotification)
        {
            if (pushNotification is null) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/SendToTopic";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(pushNotification);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult SubscribeForFireBase(SubscriptionForFireBase subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/Subscribe";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(subscription);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        /// <summary>
        /// Subscribe a given SubscriberId (all the devices related to an id) to a Topic 
        /// </summary>
        /// <param name="topicSubscribeModel">Include two properties, SubscriberId:string, Topic:string</param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public ResponseResult SubscribeToTopic(TopicSubscribeModel topicSubscribeModel)
        {
            if (topicSubscribeModel is null) throw new ArgumentNullException(nameof(topicSubscribeModel));

            const string resource = "Subscriptions/SubscribeToTopic";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(topicSubscribeModel);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        /// <summary>
        /// Unsubscribe a given SubscriberId (all the devices related to an id) from a Topic 
        /// </summary>
        /// <param name="topicSubscribeModel">Include two properties, SubscriberId:string, Topic:string</param>
        /// <param name="authenticator"></param>
        /// <returns></returns>
        public ResponseResult UnsubscribeFromTopic(TopicSubscribeModel topicSubscribeModel)
        {
            if (topicSubscribeModel is null) throw new ArgumentNullException(nameof(topicSubscribeModel));

            const string resource = "Subscriptions/UnsubscribeFromTopic";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(topicSubscribeModel);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult SubscribeForPushy(SubscriptionForPushy subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/Subscribe";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(subscription);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult UnSubscribeForFireBase(SubscriptionForFireBase subscription, Authenticator authenticator = null)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/UnSubscribe";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(subscription);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult UnSubscribeForPushy(SubscriptionForPushy subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/UnSubscribe";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(subscription);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult<SubscriberTokens> GetTopicSubscribedCount(TopicSubscriptionCountModel topicSubscriptionCountModel)
        {
            if (topicSubscriptionCountModel is null) throw new ArgumentNullException(nameof(topicSubscriptionCountModel));

            const string resource = "TopicSubscriptionCount/GetTopicSubscribedCount";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(topicSubscriptionCountModel);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult<SubscriberTokens>>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult<SubscriberTokens> GetSubscriberTokens(SubscriberTokensModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            const string resource = "Subscriptions/SubscriberTokens";

            var request = CreateRestRequest(resource, Method.POST)
                .AddJsonBody(model);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult<SubscriberTokens>>(request);
            return ResponseResult.FromRestResponse(response);
        }

        public ResponseResult<DiscoveryReaderResponseModel> Discovery()
        {
            const string resource = "Discovery/Normalized";

            var request = CreateRestRequest(resource, Method.GET);

            var response = CreateRestClient().ExecuteWithLog<ResponseResult<DiscoveryReaderResponseModel>>(request);
            return ResponseResult.FromRestResponse(response);
        }
    }


}
