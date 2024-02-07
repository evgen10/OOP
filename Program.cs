namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var documentManager = new DocumentManager();
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