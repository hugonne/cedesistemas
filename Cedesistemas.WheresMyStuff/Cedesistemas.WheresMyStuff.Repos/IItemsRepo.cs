using System.Collections.Generic;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public interface IItemsRepo
    {
        IEnumerable<Item> GetAll(bool includeLocations = false);
        Item GetById(int id);
        int Add(Item item);
        void Delete(Item item);

        void SaveChanges();
    }
}