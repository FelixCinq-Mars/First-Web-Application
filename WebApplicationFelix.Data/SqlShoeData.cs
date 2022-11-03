using WebApplicationFelix.Core;

namespace WebApplicationFelix.Data
{
    public class SqlShoeData : IShoeData
    {
        private readonly WebApplicationFelixDbContext db;

        public SqlShoeData(WebApplicationFelixDbContext db)
        {
            this.db = db;
        }
        public Shoe Add(Shoe newShoe)
        {
            db.Add(newShoe);
            return newShoe;
        }

        public int Commit()
        {
            return db.SaveChanges();    
        }

        public Shoe Delete(int id)
        {
            var shoe = GetById(id);
            if(shoe != null)
            {
                db.Shoes.Remove(shoe);
            }
            return shoe;
        }

        public Shoe GetById(int id)
        {
            return db.Shoes.Find(id);
        }

        public int GetCountOfShoes()
        {
            return db.Shoes.Count();
        }

        public IEnumerable<Shoe> GetShoesByName(string name)
        {
            var query = from r in db.Shoes
                        where r.name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.name
                        select r;
            return query;
        }

        public Shoe Update(Shoe updatedShoe)
        {
            var entity = db.Shoes.Attach(updatedShoe);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedShoe;
        }
    }
}
