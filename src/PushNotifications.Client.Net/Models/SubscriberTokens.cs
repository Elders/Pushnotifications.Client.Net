using PushNotifications.Contracts;
using System.Collections.Generic;

namespace PushNotifications.Api.Client
{
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
