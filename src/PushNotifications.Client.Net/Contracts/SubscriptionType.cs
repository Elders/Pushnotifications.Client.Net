﻿using System;

namespace PushNotifications.Contracts.Subscriptions
{
    public class SubscriptionType
    {
        public string value;

        SubscriptionType() { }

        SubscriptionType(string value)
        {
            if (string.IsNullOrEmpty(value) == true) throw new ArgumentNullException(nameof(value));
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }

        public static SubscriptionType Create(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "pushy":
                    return Pushy;
                case "firebase":
                    return FireBase;
                default:
                    throw new NotSupportedException($"Not supported subscription type: {value}");
            }
        }

        public static implicit operator string(SubscriptionType subscriptionType)
        {
            subscriptionType = subscriptionType ?? new SubscriptionType();
            return subscriptionType.value;
        }

        public static SubscriptionType Pushy = new SubscriptionType("pushy");

        public static SubscriptionType FireBase = new SubscriptionType("firebase");
    }
}
