using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DelegatingHandlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        // todo : Move access key
        private readonly IConfiguration _configuration;
        public ApiKeyHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var apikey = _configuration["CurrencylayerApiKey"];
            if (string.IsNullOrEmpty(uriBuilder.Query))
            {
                uriBuilder.Query = $"access_key={apikey}";
            }
            else
            {
                uriBuilder.Query = $"{uriBuilder.Query}&access_key={apikey}";
            }

            request.RequestUri = uriBuilder.Uri;
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
