using System.Net.Http;

namespace Tavis.Http
{
    public interface IRequestFactory
    {
        string LinkRelation { get; }
        HttpRequestMessage CreateRequest();
    }

}
