﻿using System;
using System.Collections.Generic;
using PushNotifications.Contracts;

namespace PushNotifications.Api.Client.Models
{
    public class SendPushNotificationModel
    {
        public SendPushNotificationModel(string subscriberUrn, string title, string body, string sound, string icon, int badge, Dictionary<string, object> notificationData, DateTime expiresAtUtc, bool contentAvailable)
        {
            if (ReferenceEquals(subscriberUrn, null) == true) throw new ArgumentNullException(nameof(subscriberUrn));
            if (ReferenceEquals(expiresAtUtc, null) == true) throw new ArgumentNullException(nameof(expiresAtUtc));
            if (ReferenceEquals(notificationData, null) == true) throw new ArgumentNullException(nameof(notificationData));

            SubscriberUrn = subscriberUrn;
            Title = title;
            Body = body;
            Sound = sound;
            Icon = icon;
            Badge = badge;
            ExpiresAt = new Timestamp(expiresAtUtc);
            ContentAvailable = contentAvailable;
            NotificationData = notificationData;
        }

        public string SubscriberUrn { get; private set; }

        public string Title { get; private set; }

        public string Body { get; private set; }

        public string Sound { get; private set; }

        public string Icon { get; private set; }

        public int Badge { get; private set; }

        public Timestamp ExpiresAt { get; private set; }

        public bool ContentAvailable { get; private set; }

        public Dictionary<string, object> NotificationData { get; private set; }
    }
}
