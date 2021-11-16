using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DelegatingHandlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        // todo : Move access key
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            if (string.IsNullOrEmpty(uriBuilder.Query))
            {
                uriBuilder.Query = $"access_key=aaa62d9014c6f9cc71563cb6e56abe0d";
            }
            else
            {
                uriBuilder.Query = $"{uriBuilder.Query}&access_key=aaa62d9014c6f9cc71563cb6e56abe0d";
            }

            request.RequestUri = uriBuilder.Uri;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
