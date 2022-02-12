using Polly;
using Polly.Retry;

namespace Request__Service.Policies
{
    public class ClientPolicy : IClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }

        public ClientPolicy()
        {
            ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode
                ).RetryAsync(5);

            LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode
                ).WaitAndRetryAsync(5, attempt => TimeSpan.FromSeconds(3));
        }
    }
}
