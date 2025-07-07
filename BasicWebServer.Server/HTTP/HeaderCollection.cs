namespace BasicWebServer.Server.HTTP
{
    using System.Collections;

    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> _headers;

        public HeaderCollection()
            => _headers = new Dictionary<string, Header>();

        public string this[string name]
            => _headers[name].Value;

        public int Count => _headers.Count;

        public bool Contains(string name)
            => _headers.ContainsKey(name);

        public void Add(string name, string value)
            => _headers[name] = new Header(name, value);

        public IEnumerator<Header> GetEnumerator()
            => _headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}