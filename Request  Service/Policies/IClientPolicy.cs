using Polly.Retry;

namespace Request__Service.Policies
{
    public interface IClientPolicy
    {
        AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
        AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }
    }
}