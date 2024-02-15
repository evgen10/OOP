using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Caching
{
    public interface ICaching
    {
        void Load();

        void Add(int number, Document document);

        bool TryGet(int number, out Document doc);

        ///
        /// --- another required methods
        ///
    }
}
