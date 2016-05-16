using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace Tavis.Http
{
    public class ClientBuilder : IClientBuilder
    {
        private List<DelegatingHandler> _Pipeline = new List<DelegatingHandler>();
        public HttpClient Build(HttpMessageHandler finalHandler = null)
        {
            var innerHandler = finalHandler ?? new HttpClientHandler();
            foreach (var handler in _Pipeline.Reverse<DelegatingHandler>())
            {
                handler.InnerHandler = innerHandler;
                innerHandler = handler;
            }

            return new HttpClient(innerHandler);
        }

        public IClientBuilder Use(DelegatingHandler middleware)
        {
            _Pipeline.Add(middleware);
            return this;
        }
    }
}