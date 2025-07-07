namespace BasicWebServer.Server.HTTP
{
    using Common;

    public class Header
    {
        private readonly string _name;
        private readonly string _value;

        public const string ContentType = "Content-Type";
        public const string ContentLenght = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";
        public const string Cookie = "Cookie";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string SetCookie = "Set-Cookie";

        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            _name = name;
            _value = value;
        }

        public string Name { get; init; }

        public string Value { get; set; }

        public override string ToString()
            => $"{_name}: {_value}";
    }
}