using System;

namespace PushNotifications.Api.Client
{
    public class FireBaseTopicSubscribeModel
    {
        public FireBaseTopicSubscribeModel(string subscriberId, string topic)
        {
            if (ReferenceEquals(subscriberId, null) == true) throw new ArgumentNullException(nameof(subscriberId));
            if (string.IsNullOrEmpty(topic) == true) throw new ArgumentNullException(nameof(topic));

            SubscriberUrn = subscriberId;
            Token = topic;
        }

        public string SubscriberUrn { get; private set; }

        public string Token { get; private set; }
    }
}
