using Cedesistemas.WheresMyStuff.DataAccess;
using Cedesistemas.WheresMyStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly ApplicationDbContext _context;

        public ItemsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Item item)
        {
            return _context.Items.Add(item).Entity.Id;
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.OrderBy(a => a.Name);
        }

        public IEnumerable<Item> GetRecentItems()
        {
            var items =
                from a in _context.Items
                where a.DateTime >= DateTime.Now.AddDays(-7) && a.IsVisibleForAll
                select a;

            var lambdaItems = _context.Items
                .Where(a => a.DateTime >= DateTime.Now.AddDays(-7) && a.IsVisibleForAll)
                .Select(a => a.Name);

            return items;
        }

        public Item GetById(int id)
        {
            return _context.Items.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
