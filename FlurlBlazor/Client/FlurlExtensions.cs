using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;

namespace FlurlBlazor.Client
{
    public static class FlurlExtensions
    {
        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions { IgnoreNullValues = true };

        public static Task<HttpResponseMessage> PatchAsJsonAsync<TContent>(this IFlurlRequest request, TContent content, JsonSerializerOptions jsonSerializerOptions, CancellationToken cancellationToken = default)
            => request.SendAsync(HttpMethod.Patch, JsonContent.Create(request, options: jsonSerializerOptions ?? serializerOptions), cancellationToken);

        public static Task<HttpResponseMessage> PostAsJsonAsync<TContent>(this IFlurlRequest request, TContent content, JsonSerializerOptions jsonSerializerOptions, CancellationToken cancellationToken = default)
            => request.SendAsync(HttpMethod.Post, JsonContent.Create(request, options: jsonSerializerOptions ?? serializerOptions), cancellationToken);

        public static Task<HttpResponseMessage> PutAsJsonAsync<TContent>(this IFlurlRequest request, TContent content, JsonSerializerOptions jsonSerializerOptions, CancellationToken cancellationToken = default)
            => request.SendAsync(HttpMethod.Put, JsonContent.Create(request, options: jsonSerializerOptions ?? serializerOptions), cancellationToken);

    }
}