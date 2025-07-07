namespace BasicWebServer.Server.Responses
{
    using HTTP;

    public class BadReqeustResponse : Response
    {
        public BadReqeustResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}