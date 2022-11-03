using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationFelix.Core;

namespace WebApplicationFelix.Data
{
    public interface IShoeData
    {
        IEnumerable<Shoe> GetShoesByName(string name);
        Shoe GetById(int id);
        Shoe Update(Shoe updatedShoe);
        Shoe Add(Shoe newShoe);
        int Commit();
        int GetCountOfShoes();
        Shoe Delete(int id);
    }
}
