using OOP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Caching
{
    public class InMemoryCache : ICaching
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, Document> _cache = new Dictionary<string, Document>();


        public InMemoryCache(ILogger logger)
        {
            _logger = logger;
        }

        public void Add(string number, Document document)
        {
            _cache.TryAdd(number, document);
        }

        public void Load()
        {
            // Load data from storage
        }

        public bool TryGet(string number, out Document doc)
        {
            var isExist = _cache.TryGetValue(number, out var result);
            doc = result;

            _logger.Log("Found in cache:");

            return isExist;
        }
    }
}
