using Polly.Retry;

namespace Request__Service.Policies
{
    public interface IClientPolicy
    {
        AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }
        AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
        AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }
    }
}