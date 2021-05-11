using System.Collections.Generic;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public interface IStuffRepo
    {
        IEnumerable<Stuff> GetAll();
        Stuff GetById(int id);
        void Add(Stuff stuff);
        void Update(Stuff stuff);
        void Delete(Stuff stuff);
    }
}