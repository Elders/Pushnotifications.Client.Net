using System;
using System.Diagnostics;
using PushNotifications.Client.Net.Logging;
using RestSharp;

namespace PushNotifications.Client.Net
{
    public static class RestSharpExtensions
    {
        static readonly ILog log = LogProvider.GetLogger(typeof(PushNotificationsClient));

        public static IRestResponse<T> ExecuteWithLog<T>(this IRestClient client, IRestRequest request) where T : new()
        {
            double TimestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

            long startTimestamp = 0;
            if (log.IsInfoEnabled())
            {
                log.Info($"Request starting {request.Method} `{client.BaseUrl}/{request.Resource}`");
                startTimestamp = Stopwatch.GetTimestamp();
            }

            var response = client.Execute<T>(request);

            if (log.IsInfoEnabled())
            {
                var elapsed = new TimeSpan((long)(TimestampToTicks * (Stopwatch.GetTimestamp() - startTimestamp)));
                log.Info($"Request finished {request.Method} `{client.BaseUrl}{request.Resource}` finished in {elapsed.TotalMilliseconds}ms - {response.StatusCode}");
            }

            if (response.IsSuccessful == false)
            {
                log.Error(response.ErrorException, $"Request failed {request.Method} `{client.BaseUrl}{request.Resource}` - {response.StatusCode} {Environment.NewLine} {response.ErrorMessage} {Environment.NewLine} {response.Content}");
            }

            return response;
        }
        public static IRestRequest AddAuthorizationBearerHeader(this IRestRequest request, Authenticator auth)
        {
            return request.AddHeader("Authorization", "Bearer " + auth.AccessToken);
        }

    }
}
