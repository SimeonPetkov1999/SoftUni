using SIS.Server.Common;
using SIS.Server.HTTP;
using SIS.Server.Responses;

namespace SIS.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable() =>
            this.routes = new Dictionary<Method, Dictionary<string, Response>>()
            {
                [Method.Get] = new(),
                [Method.Post] = new(),
                [Method.Put] = new(),
                [Method.Delete] = new(),
            };

        public IRoutingTable Map(string url, Method method, Response response) =>
            method switch
            {
                Method.Get => this.MapGet(url, response),
                Method.Post => this.MapPost(url, response),
                _ => throw new InvalidOperationException($"Method '{method}' is not supported."),
            };


        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.Get][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[Method.Post][url] = response;

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var requesteMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requesteMethod)
                || !this.routes[requesteMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requesteMethod][requestUrl];

        }
    }
}
