using SIS.Server.HTTP;

namespace SIS.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Method method,
            string path,
            Func<Request, Response> responseFuncition);

        IRoutingTable MapGet(string path, Func<Request, Response> responseFuncition);

        IRoutingTable MapPost(string path, Func<Request, Response> responseFuncition);
    }
}
