using System;
using System.Collections.Generic;
using PushNotifications.Contracts;

namespace PushNotifications.Api.Client.Models
{
    public class SendPushNotificationToTopicModel
    {
        public SendPushNotificationToTopicModel(string topic, string tenant, string title, string body, string sound, string icon, int badge, DateTime expiresAtUtc, bool contentAvailable, Dictionary<string, object> notificationData)
        {
            if (topic is null) throw new ArgumentNullException(nameof(topic));
            if (notificationData is null) throw new ArgumentNullException(nameof(notificationData));
            if (ReferenceEquals(null, expiresAtUtc)) throw new ArgumentNullException(nameof(expiresAtUtc));

            Topic = topic;
            Tenant = tenant;
            Title = title;
            Body = body;
            Sound = sound;
            Icon = icon;
            Badge = badge;
            ExpiresAt = new Timestamp(expiresAtUtc);
            ContentAvailable = contentAvailable;
            NotificationData = notificationData;
        }

        public string Topic { get; private set; }

        public string Tenant { get; private set; }

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
