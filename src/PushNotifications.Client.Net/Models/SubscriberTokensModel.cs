namespace PushNotifications.Client.Net
{
    public class SubscriberTokensModel
    {
        public SubscriberTokensModel(string subscriberUrn)
        {
            SubscriberUrn = subscriberUrn;
        }

        public string SubscriberUrn { get; private set; }
    }
}
