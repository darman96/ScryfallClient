using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ScryfallClient.Converters;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility;
using ScryfallClient.Utility.Interfaces;

namespace ScryfallClient.Endpoints
{
    public abstract class BaseEndpoints
    {
        private readonly HttpClient httpClient;
        private readonly IRequestUriFactory uriFactory;
        private readonly IRequestBodyFactory bodyFactory;

        protected BaseEndpoints(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.uriFactory = new RequestUriFactory(new PathSegementParser());
            this.bodyFactory = new RequestBodyFactory();
        }

        protected async Task<T> ExecuteRequestAsync<T>(IRequest request)
        {
            HttpResponseMessage response;
            var requestUri = uriFactory.Create(request);

            switch (request.Method)
            {
                case "GET":
                    response = await httpClient.GetAsync(requestUri);
                    break;
                case "POST":
                    var requestBody = bodyFactory.Create(request);
                    using (var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json"))
                    {
                         response = await httpClient.PostAsync(requestUri, content);
                    }
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported HTTP method: {request.Method}");
            }

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<T>(getJsonSerializerOptions());
            return result ?? throw new InvalidOperationException("Failed to deserialize response.");
        }

        private JsonSerializerOptions getJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                Converters =
                {
                    new ScryfallObjectTypeJsonConverter(),
                    new ScryfallImageVersionJsonConverter()
                }
            };
        }
    }
}
