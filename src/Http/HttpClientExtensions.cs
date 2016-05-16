using System.Net.Http;
using System.Threading.Tasks;

namespace Tavis.Http
{
    public static class HttpClientExtensions
    {
        public const string PropertyKeyRequestFactory = "tavis.requestfactory";

        public static Task<HttpResponseMessage> FollowLinkAsync(this HttpClient httpClient, IRequestFactory requestFactory, IResponseHandler handler = null)
        {
            var httpRequestMessage = requestFactory.CreateRequest();
            httpRequestMessage.Properties[PropertyKeyRequestFactory] = requestFactory;
            return httpClient.SendAsync(httpRequestMessage).ApplyRepresentationToAsync(handler);
        }
    }
}