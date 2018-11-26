using System;

namespace PushNotifications.Client.Net
{
    public sealed partial class PushNotificationsClient
    {
        Options options;
        Authenticator authenticator;

        public PushNotificationsClient(Options options, Authenticator authenticator)
        {
            if (ReferenceEquals(null, options)) throw new ArgumentNullException(nameof(options));
            this.options = options;

            this.authenticator = authenticator;
        }

        public sealed class Options
        {
            public Options(Uri apiAddress)
            {
                ApiAddress = apiAddress;
                JsonSerializer = RestSharpSerializer.Default();
            }

            public Uri ApiAddress { get; private set; }
            public IJsonSerializer JsonSerializer { get; private set; }
        }
    }
}
