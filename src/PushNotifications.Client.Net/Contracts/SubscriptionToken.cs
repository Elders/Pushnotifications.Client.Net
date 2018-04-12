using System;
using PushNotifications.Contracts.Subscriptions;

namespace PushNotifications.Contracts
{
    public class SubscriptionToken
    {
        SubscriptionToken() { }

        public SubscriptionToken(string token, SubscriptionType subscriptionType)
        {
            if (string.IsNullOrEmpty(token) == true) throw new ArgumentNullException(nameof(token));
            if (ReferenceEquals(null, subscriptionType) == true) throw new ArgumentNullException(nameof(subscriptionType));

            Token = token;
            SubscriptionType = subscriptionType;
        }

        public string Token { get; private set; }

        public SubscriptionType SubscriptionType { get; private set; }

        public override string ToString()
        {
            return Token;
        }

        public static implicit operator string(SubscriptionToken token)
        {
            return token.ToString();
        }

        public static bool IsValid(SubscriptionToken token)
        {
            if (ReferenceEquals(null, token) == true)
                return false;

            return true;
        }
    }
}
