﻿namespace BasicWebServer.Server.Routing
{
    using HTTP;

    public interface IRoutingTable
    {
        IRoutingTable Map(Method method,string path, Func<Request,Response> responseFunction);

        IRoutingTable MapGet(string path, Func<Request, Response> responseFunction);

        IRoutingTable MapPost(string path, Func<Request, Response> responseFunction);
    }
}