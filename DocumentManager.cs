﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OOP.Caching;
using OOP.Logging;
using OOP.Storage;

namespace OOP
{
    public class DocumentManager
    {
        private readonly IDocumentStorage _documentStorage;
        private readonly ICaching _cache;
        private readonly ILogger _logger;
        

        public DocumentManager(IDocumentStorage documentStorage, ICaching cache, ILogger logger)
        {
            _documentStorage = documentStorage;
            _cache = cache;
            _logger = logger;
        }


        public Document? SearchDocumentByNumber(int number)
        {
            if (_cache.TryGet(number, out var doc))
                return doc;       

            var documentFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*_{number}.json");

            foreach (var file in documentFiles)
            {
                var documentType = Path.GetFileNameWithoutExtension(file).Split('_')[0].ToLower();

                switch (documentType)
                {
                    case "patent": /// use Enum instead
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
                        _cache.Add(number,magazine);
                        return magazine;
                    default:
                        _logger.Log("Unsupported document type");
                        return null;
                }
            }

            _logger.Log("Document not found");
            return null;
        }
    }
}
