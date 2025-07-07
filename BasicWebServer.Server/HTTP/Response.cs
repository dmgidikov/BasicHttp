namespace BasicWebServer.Server.HTTP
{
    using System.Text;

    public class Response
    {
        private StatusCode _statusCode;
        private HeaderCollection _headers = new HeaderCollection();
        private CookieCollection _cookies = new CookieCollection();

        public Response(StatusCode statusCode)
        {
            _statusCode = statusCode;

            _headers.Add(Header.Server, "My Web Server");
            _headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers => _headers;

        public CookieCollection Cookies => _cookies;

        public string Body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)_statusCode} {_statusCode}");

            foreach (var header in _headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in _cookies)
            {
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(Body))
            {
                result.Append(Body);
            }

            return result.ToString();
        }
    }
}