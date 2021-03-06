﻿using System;

namespace PushNotifications.Api.Client
{
    public class TopicSubscribeModel
    {
        public TopicSubscribeModel(string subscriberId, string topic)
        {
            if (subscriberId is null) throw new ArgumentNullException(nameof(subscriberId));
            if (string.IsNullOrEmpty(topic) == true) throw new ArgumentNullException(nameof(topic));

            SubscriberId = subscriberId;
            Topic = topic;
        }

        public string SubscriberId { get; private set; }

        public string Topic { get; private set; }
    }
}
