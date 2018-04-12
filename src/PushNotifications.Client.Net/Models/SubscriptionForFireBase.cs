using System;

namespace PushNotifications.Api.Client
{
    public class SubscriptionForFireBase
    {
        public SubscriptionForFireBase(string subscriberUrn, string token)
        {
            if (ReferenceEquals(subscriberUrn, null) == true) throw new ArgumentNullException(nameof(subscriberUrn));
            if (string.IsNullOrEmpty(token) == true) throw new ArgumentNullException(nameof(token));

            SubscriberUrn = subscriberUrn;
            Token = token;
        }

        public string SubscriberUrn { get; private set; }

        public string Token { get; private set; }
    }
}
