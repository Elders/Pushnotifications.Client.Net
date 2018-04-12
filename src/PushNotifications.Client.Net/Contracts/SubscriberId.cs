using PushNotifications.Api.Client;
using System;

namespace PushNotifications.Contracts
{
    public class SubscriberId : IHaveUrn
    {
        public SubscriberId(string urn)
        {
            if (string.IsNullOrEmpty(urn)) throw new ArgumentNullException(nameof(urn));

            Urn = urn;
        }

        public SubscriberId(string id, string tenant)
        {
            Urn = $"urn:{tenant}:subscriber:{id}";
        }

        public string Urn { get; private set; }
    }
}
