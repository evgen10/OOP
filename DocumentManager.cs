using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOP
{
    public class DocumentManager
    {
        private Dictionary<string, Document> cache = new Dictionary<string, Document>();

        public Document? SearchDocumentByNumber(string number)
        {
            if (cache.ContainsKey(number))
            {
                Console.WriteLine("Found in cache:");
                return cache[number];
            }

            var documentFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*_{number}.json");

            foreach (var file in documentFiles)
            {
                var documentType = Path.GetFileNameWithoutExtension(file).Split('_')[0].ToLower();

                switch (documentType)
                {
                    case "patent":
                        var patent = JsonConvert.DeserializeObject<Patent>(File.ReadAllText(file));
                        cache[number] = patent;
                        return patent;
                    case "book":
                        var book = JsonConvert.DeserializeObject<Book>(File.ReadAllText(file));
                        cache[number] = book;
                        return book;
                    case "localizedbook":
                        var localizedBook = JsonConvert.DeserializeObject<LocalizedBook>(File.ReadAllText(file));
                        cache[number] = localizedBook;
                        return localizedBook;
                    case "magazine":
                        var magazine = JsonConvert.DeserializeObject<Magazine>(File.ReadAllText(file));
                        cache[number] = magazine;
                        return magazine;
                    default:
                        Console.WriteLine("Unsupported document type");
                        return null;
                }
            }

            Console.WriteLine("Document not found");
            return null;
        }
    }
}
