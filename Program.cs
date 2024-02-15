using OOP.Caching;
using OOP.Logging;
using OOP.Storage;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // could be some kind of fabric or bulder
            var logger = new ConsoleLogger();
            var caching = new InMemoryCache(logger);

            var documentManager = new DocumentManager(
                new FileSystemStorage(caching, logger),
                caching,
                logger);


            Console.Write("Enter document number to search: ");
            string documentNumber = Console.ReadLine();

            Document document = documentManager.SearchDocumentByNumber(documentNumber);

            if (document != null)
            {
                Console.WriteLine(document.GetCardInfo());
            }
        }
    }
}