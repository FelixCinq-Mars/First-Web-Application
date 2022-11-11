using WebApplicationFelix.Core;

namespace WebApplicationFelix.Data
{
    public class InMemoryShoeData : IShoeData
    {
        List<Shoe> shoes;

        public InMemoryShoeData()
        {
            shoes = new List<Shoe>()
            {
                new Shoe { id = 1, name = "Veja Condor", cost = 168, color="Blue", type = ShoeType.Road},
                new Shoe { id = 2, name = "On Cyclon", cost = 300, color="White", type = ShoeType.Trail},
                new Shoe { id = 3, name = "Allbirds Tree Flyer", cost = 230, color="Orange/White", type = ShoeType.Road}
            };
        }
        public Shoe GetById(int id)
        {
            return shoes.SingleOrDefault(r => r.id == id);
        }
        public Shoe Add(Shoe newShoe)
        {
            shoes.Add(newShoe);
            newShoe.id = shoes.Max(r => r.id) + 1;
            return newShoe;
        }

        public Shoe Update(Shoe updatedShoe)
        {
            var shoe = shoes.SingleOrDefault(r => r.id == updatedShoe.id);
            if(shoe != null)
            {
                shoe.name = updatedShoe.name;
                shoe.color = updatedShoe.color;
                shoe.cost = updatedShoe.cost;
                shoe.type = updatedShoe.type;
            }
            return shoe;
        }
      
        public int Commit()
        {
            return 0;
        }


        public IEnumerable<Shoe> GetShoesByName(string name)
        {
            return from r in shoes
                   where string.IsNullOrEmpty(name) || r.name.StartsWith(name)
                   orderby r.name
                   select r;
        }

        public Shoe Delete(int id)
        {
            var shoe = shoes.FirstOrDefault(r => r.id == id);
            if(shoe != null)
            {
                shoes.Remove(shoe);
            }
            return shoe;
        }

        public int GetCountOfShoes()
        {
            return shoes.Count();
        }
    }
}
