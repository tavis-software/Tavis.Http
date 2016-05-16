using System.Net.Http;
using System.Threading.Tasks;

namespace Tavis.Http
{
    public interface IResponseHandler
    {
        Task<HttpResponseMessage> HandleResponseAsync(IRequestFactory requestFactory, HttpResponseMessage responseMessage);
    }
}
