using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Storage
{
    public interface IDocumentStorage
    {
        void AddToStore(Document document);
        Document GetFromStore(int number);

        ///
        /// --- another required methods
        ///
    }
}
