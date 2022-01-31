using SIS.Server.Common;
using SIS.Server.HTTP;
using SIS.Server.Responses;

namespace SIS.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method,
            Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable() =>
            this.routes = new()
            {
                [Method.Get] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Post] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Put] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.Delete] = new(StringComparer.InvariantCultureIgnoreCase),
            };

        public IRoutingTable Map(Method method,
            string path,
            Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFuncition)
            => Map(Method.Get, path, responseFuncition);
        public IRoutingTable MapPost(string path, Func<Request, Response> responseFuncition)
        => Map(Method.Post, path, responseFuncition);


        public Response MatchRequest(Request request)
        {
            var requesteMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requesteMethod)
                || !this.routes[requesteMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requesteMethod][requestUrl];

            return responseFunction(request);

        }
    }
}
