namespace BasicWebServer.Server.Responses
{
    using HTTP;

    public class TextFileResponse : Response
    {
        private string _fileName;        

        public TextFileResponse(string fileName)
            : base(StatusCode.OK)
        {
            _fileName = fileName;

            Headers.Add(Header.ContentType, ContentType.PlainText);
        }

        public string? FileName { get; init; }

        public override string ToString()
        {
            if (File.Exists(_fileName))
            {
                Body = File.ReadAllTextAsync(_fileName).Result;

                var fileBytesCount = new FileInfo(_fileName).Length;
                Headers.Add(Header.ContentLenght, fileBytesCount.ToString());

                Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{Path.GetFileName(_fileName)}\"");               
            }

            return base.ToString();
        }
    }
}