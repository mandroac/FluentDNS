using FDNS.Common.Configuration;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using Microsoft.Extensions.Options;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Services
{
    public class NamecheapApiBaseService : INamecheapApiBaseService
    {
        private readonly NamecheapApiConfiguration _config;

        protected readonly IHttpClientFactory HttpClientFactory;
        protected readonly XNamespace NS = XNamespace.Get("http://api.namecheap.com/xml.response");
        protected NamecheapGlobalParameters GlobalParams;

        private bool _isSandbox = true;

        public bool IsSandbox
        {
            get => _isSandbox;
            set
            {
                _isSandbox = value;
                if (value)
                    GlobalParams = _config.Sandbox;
                else
                    GlobalParams = _config.Production;
            }
        }

        public NamecheapApiBaseService(IHttpClientFactory httpClientFactory, IOptions<NamecheapApiConfiguration> options)
        {
            HttpClientFactory = httpClientFactory;
            _config = options.Value;
            GlobalParams = _config.Sandbox;
        }

        internal protected async Task<XElement> SendRequestAsync<T>(HttpRequestMessage request)  where T : class
        {
            var client = HttpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(content);

                if (doc.Root.Attribute("Status").Value.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException(string.Join(",", doc.Root.Element(NS + "Errors").Elements(NS + "Error").Select(o => $"{o.Attribute("Number").Value}: {o.Value}")));

                return doc.Root.Element(NS + "CommandResponse").Element(NS + typeof(T).Name);
            }
            else
            {
                throw new ApplicationException($"{response.StatusCode}: {response.ReasonPhrase}.");
            }
        }

        internal protected async Task<XElement> SendRequestAsync(HttpRequestMessage request)
        {
            var client = HttpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(content);

                if (doc.Root.Attribute("Status").Value.Equals("ERROR", StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException(string.Join(",", doc.Root.Element(NS + "Errors").Elements(NS + "Error").Select(o => $"{o.Attribute("Number").Value}: {o.Value}")));

                return doc.Root.Element(NS + "CommandResponse");
            }
            else
            {
                throw new ApplicationException($"{response.StatusCode}: {response.ReasonPhrase}.");
            }
        }

        internal protected T DeserializeElement<T>(XElement element) where T : class
        {
            var serializer = new XmlSerializer(typeof(T), NS.NamespaceName);
            return (T)serializer.Deserialize(element.CreateReader());
        }
    }
}