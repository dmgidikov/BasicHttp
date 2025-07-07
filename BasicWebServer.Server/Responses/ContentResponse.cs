namespace BasicWebServer.Server.Responses
{
    using HTTP;
    using Common;
    using System.Text;

    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            Headers.Add(Header.ContentType, contentType);

            Body = content;
        }

        public override string ToString()
        {
            if (Body != null)
            {
                var contentLenght = Encoding.UTF8.GetByteCount(Body).ToString();
                Headers.Add(Header.ContentLenght, contentLenght);
            }

            return base.ToString();
        }
    }
}