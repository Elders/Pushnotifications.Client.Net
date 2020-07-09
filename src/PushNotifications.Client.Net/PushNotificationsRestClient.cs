using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace PushNotifications.Client.Net
{
    public partial class PushNotificationsHttpClient
    {
        private readonly HttpClient _httpClient;

        public PushNotificationsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ResponseResult SendPushNotification(SendPushNotificationModel pushNotification)
        {
            if (pushNotification is null) throw new ArgumentNullException(nameof(pushNotification));

            const string resource = "PushNotifications/Send";

            var requesBody = new StringContent(JsonConvert.SerializeObject(pushNotification), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
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

            var requesBody = new StringContent(JsonConvert.SerializeObject(pushNotification), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
        }

        public ResponseResult SubscribeForFireBase(SubscriptionForFireBase subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/Subscribe";

            var requesBody = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
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

            var requesBody = new StringContent(JsonConvert.SerializeObject(topicSubscribeModel), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
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

            var requesBody = new StringContent(JsonConvert.SerializeObject(topicSubscribeModel), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
        }

        public ResponseResult SubscribeForPushy(SubscriptionForPushy subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/Subscribe";

            var requesBody = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
        }

        public ResponseResult UnSubscribeForFireBase(SubscriptionForFireBase subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/FireBaseSubscription/UnSubscribe";

            var requesBody = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
        }

        public ResponseResult UnSubscribeForPushy(SubscriptionForPushy subscription)
        {
            if (subscription is null) throw new ArgumentNullException(nameof(subscription));

            const string resource = "Subscriptions/PushySubscription/UnSubscribe";

            var requesBody = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(resource, requesBody).Result;

            if (response.IsSuccessStatusCode == false)
                return ResponseResult.Success;

            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult>(content);
        }

        public ResponseResult<SubscriberTokens> GetTopicSubscribedCount(TopicSubscriptionCountModel topicSubscriptionCountModel)
        {
            if (topicSubscriptionCountModel is null) throw new ArgumentNullException(nameof(topicSubscriptionCountModel));

            string resource = $"TopicSubscriptionCount/GetTopicSubscribedCount?name={topicSubscriptionCountModel.Name}";

            var response = _httpClient.GetAsync(resource).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode == false)
                return new ResponseResult<SubscriberTokens>(response.ReasonPhrase);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult<SubscriberTokens>>(content);
        }

        public ResponseResult<SubscriberTokens> GetSubscriberTokens(SubscriberTokensModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            string resource = $"Subscriptions/SubscriberTokens?SubscriberUrn={model.SubscriberUrn}";

            var response = _httpClient.GetAsync(resource).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode == false)
                return new ResponseResult<SubscriberTokens>(response.ReasonPhrase);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult<SubscriberTokens>>(content);
        }

        public ResponseResult<DiscoveryReaderResponseModel> Discovery()
        {
            const string resource = "Discovery/Normalized";


            var response = _httpClient.GetAsync(resource).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode == false)
                return new ResponseResult<DiscoveryReaderResponseModel>(response.ReasonPhrase);

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<ResponseResult<DiscoveryReaderResponseModel>>(content);
        }
    }
}
