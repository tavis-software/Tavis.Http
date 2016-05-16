using System.Net.Http;
using System.Threading.Tasks;


namespace Tavis.Http
{
    public static class TaskExtensions
    {

        public static async Task<HttpResponseMessage> ApplyRepresentationToAsync(this Task<HttpResponseMessage> task, IResponseHandler responseHandler)
        {
            // What do we do with exceptions that happen here?               
            
            HttpResponseMessage response = await task;
            if (task.IsCompleted && responseHandler != null)
            {
                response = task.Result;
                IRequestFactory rf = null;
                if (response.RequestMessage.Properties.ContainsKey(HttpClientExtensions.PropertyKeyRequestFactory))
                {
                        rf = response.RequestMessage.Properties[HttpClientExtensions.PropertyKeyRequestFactory] as IRequestFactory;
                }
                response = await responseHandler.HandleResponseAsync(rf, response);
            }
            return response;
            
        }
    }
}