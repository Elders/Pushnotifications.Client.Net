using System;

namespace PushNotifications.Api.Client
{
    public class FireBaseTopicSubscribeModel
    {
        public FireBaseTopicSubscribeModel(string subscriberId, string topic)
        {
            if (subscriberId is null) throw new ArgumentNullException(nameof(subscriberId));
            if (string.IsNullOrEmpty(topic) == true) throw new ArgumentNullException(nameof(topic));

            SubscriberId = subscriberId;
            Token = topic;
        }

        public string SubscriberId { get; private set; }

        public string Token { get; private set; }
    }
}
