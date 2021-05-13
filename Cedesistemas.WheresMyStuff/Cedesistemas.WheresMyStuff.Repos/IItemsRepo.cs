using System.Collections.Generic;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public interface IItemsRepo
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        int Add(Item stuff);
        void Update(Item stuff);
        void Delete(Item stuff);
    }
}