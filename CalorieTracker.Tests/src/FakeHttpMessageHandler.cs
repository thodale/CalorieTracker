using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CalorieTracker.Tests;

public class FakeHttpMessageHandler(string responseContent) : HttpMessageHandler {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken) {
        return Task.FromResult(
            new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(responseContent)
            }
        );
    }
}