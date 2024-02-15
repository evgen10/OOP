using Newtonsoft.Json;
using OOP.Caching;
using OOP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Storage
{
    internal class FileSystemStorage : IDocumentStorage
    {
        private readonly ILogger _logger;
        private readonly ICaching _cache;

        public FileSystemStorage(ICaching cache, ILogger logger)
        {
            _cache = cache;
            _logger = logger;            
        }

        public void AddToStore(Document document)
        {
            throw new NotImplementedException();
        }

        public Document GetFromStore(int number)
        {
            var documentFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*_{number}.json");

            foreach (var file in documentFiles)
            {
                var documentType = Path.GetFileNameWithoutExtension(file).Split('_')[0].ToLower();

                switch (documentType)
                {
                    case "patent":
                        var patent = JsonConvert.DeserializeObject<Patent>(File.ReadAllText(file));
                        _cache.Add(number, patent);
                        return patent;
                    case "book":
                        var book = JsonConvert.DeserializeObject<Book>(File.ReadAllText(file));
                        _cache.Add(number, book);
                        return book;
                    case "localizedbook":
                        var localizedBook = JsonConvert.DeserializeObject<LocalizedBook>(File.ReadAllText(file));
                        _cache.Add(number, localizedBook);
                        return localizedBook;
                    case "magazine":
                        var magazine = JsonConvert.DeserializeObject<Magazine>(File.ReadAllText(file));
                        _cache.Add(number, magazine);
                        return magazine;
                    default:
                        Console.WriteLine("Unsupported document type");
                        return null;
                }


            }

            return null;
        }
    }
}
