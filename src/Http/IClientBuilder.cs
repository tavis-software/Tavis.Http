using System.Net.Http;

namespace Tavis.Http
{
    public interface IClientBuilder
    {
        IClientBuilder Use(DelegatingHandler middleware);
        HttpClient Build(HttpMessageHandler finalHandler);
    }
}